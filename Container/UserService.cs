using AutoMapper;
using Lotus_surrogacy_agency_Admin_panel.Modal;
using Lotus_surrogacy_agency_Admin_panel.Models;
using Lotus_surrogacy_agency_Admin_panel.Service;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Container
{
    public class UserService : IUserService
    {
        private readonly LotusFertilitySurrogacyContext context;
        private readonly IMapper mapper;
        public UserService(LotusFertilitySurrogacyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<APIResponse> ConfirmRegistration(int userid, string username, string otptext)
        {
            APIResponse response = new APIResponse();

            // Validate OTP
            bool otpresponse = await ValidateOTP(username, otptext);
            if (!otpresponse)
            {
                response.Result = "Failed";
                response.message = "Invalid OTP or Expired";
                return response;
            }

            // Fetch the temp data
            var tempdata = await this.context.Tbltempusers.FirstOrDefaultAsync(item => item.UserId == userid);
            if (tempdata == null)
            {
                response.Result = "Failed";
                response.message = "Temporary user data not found";
                return response;
            }

            // Create the user entity for tbluser
            var user = new Tbluser
            {
                Username = username,
                Fullname = tempdata.Fullname,
                Password = tempdata.Password,
                Email = tempdata.Email,
                Phone = tempdata.Phone,
                Gender = tempdata.Gender,
                Role = tempdata.Role,
                Status = tempdata.Status,
                Address = tempdata.Address,
                Isactive = true
            };

            // Add the user to the tblusers table
            await this.context.Tblusers.AddAsync(user);

            // Create role-specific entity based on user role
            object roleEntity = null;

            switch (tempdata.Role)
            {
                case "admin":
                    roleEntity = new Tbladmin
                    {
                        AdminId = userid,
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.Tbladmins.AddAsync((Tbladmin)roleEntity);
                    break;

                case "Attorney":
                    roleEntity = new Tblattorney
                    {
                        AttorneyId = userid,
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.Tblattorneys.AddAsync((Tblattorney)roleEntity);
                    break;

                case "Intended Parent":
                    roleEntity = new TblintendedParent
                    {
                        ParentsId = userid,
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.TblintendedParents.AddAsync((TblintendedParent)roleEntity);
                    break;

                case "Surrogate Mother":
                    roleEntity = new TblsurrogateMother
                    {
                        MotherId = userid,
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.TblsurrogateMothers.AddAsync((TblsurrogateMother)roleEntity);
                    break;

                case "Pharmacist":
                    roleEntity = new Tblpharmacist
                    {
                        PharmacistId = userid,
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.Tblpharmacists.AddAsync((Tblpharmacist)roleEntity);
                    break;

                case "Sperm Donor":
                    roleEntity = new TblspermDonor
                    {
                        DonorId = userid,
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.TblspermDonors.AddAsync((TblspermDonor)roleEntity);
                    break;

                case "Technician":
                    roleEntity = new TbllabTechnician
                    {
                        LabTechnicianId = userid,
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.TbllabTechnicians.AddAsync((TbllabTechnician)roleEntity);
                    break;

                case "Inventory Manager":
                    roleEntity = new TblinventoryManager
                    {
                        InventoryId = userid,
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.TblinventoryManagers.AddAsync((TblinventoryManager)roleEntity);
                    break;

                case "Finance Manager":
                    roleEntity = new TblfinanceManager
                    {
                        FinanceId = userid,
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.TblfinanceManagers.AddAsync((TblfinanceManager)roleEntity);
                    break;

                case "Doctor":
                    roleEntity = new Tbldoctor
                    {
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.Tbldoctors.AddAsync((Tbldoctor)roleEntity);
                    break;

                case "Supplier":
                    roleEntity = new Tblsupplier
                    {
                        Username = username,
                        Fullname = tempdata.Fullname,
                        Password = tempdata.Password,
                        Email = tempdata.Email,
                        Phone = tempdata.Phone,
                        Gender = tempdata.Gender,
                        Status = tempdata.Isactive,
                        Address = tempdata.Address
                    };
                    await this.context.Tblsuppliers.AddAsync((Tblsupplier)roleEntity);
                    break;

                default:
                    response.Result = "Failed";
                    response.message = "Invalid role";
                    return response;
            }

            // Save changes to the database
            await this.context.SaveChangesAsync();

            // Update password manager (if applicable)
            await UpdatePwdManager(username, tempdata.Password);

            // Return success response
            response.Result = "Pass";
            response.message = "Registered successfully";
            return response;
        }


        public async Task<APIResponse> ForgotPassword(string username)
        {
            APIResponse response = new APIResponse();
            var user = await this.context.Tblusers.FirstOrDefaultAsync(item => item.Username == username && item.Isactive == true);
            if (user != null)
            {
                string otptext = Generaterandomnumber();
                await UpdateOtp(username, otptext, "Forgot password");
                //await SendOtpMail(user.Email, otptext, username);
                response.Result = "Pass";
                response.message = "OTP sent";
            }
            else
            {
                response.Result = "Failed";
                response.message = "Invalid user";
            }
            return response;
        }

        public async Task<List<UserModal>> GetUsers()
        {
            List<UserModal> _response = new List<UserModal>();
            var _data = await this.context.Tblusers.ToListAsync();
            if (_data != null)
            {
                _response = this.mapper.Map<List<Tbluser>, List<UserModal>>(_data);
            }
            return _response;
        }

        public async Task<APIResponse> ResetPassword(string username, string oldpassword, string newpassword)
        {
            APIResponse response = new APIResponse();
            var user = await this.context.Tblusers.FirstOrDefaultAsync(item => item.Username == username && item.Password == oldpassword && item.Isactive == true);
            if (user != null)
            {
                var _pwdhistory = await ValidatePWDHistory(username, newpassword);
                if (_pwdhistory)
                {
                    response.Result = "Failed";
                    response.message = "Don't use the same password used in the last 3 transactions";
                }
                else
                {
                    user.Password = newpassword;
                    await this.context.SaveChangesAsync();
                    await UpdatePwdManager(username, newpassword);
                    response.Result = "Pass";
                    response.message = "Password changed successfully";
                }
            }
            else
            {
                response.Result = "Failed";
                response.ErrorMessage = "Failed to validate old password";
            }
            return response;
        }

        public async Task<APIResponse> UpdatePassword(string username, string password, string otptext)
        {
            APIResponse response = new APIResponse();
            bool otpvalidation = await ValidateOTP(username, otptext);
            if (otpvalidation)
            {
                bool pwdhistory = await ValidatePWDHistory(username, password);
                if (pwdhistory)
                {
                    response.Result = "Fail";
                    response.message = "Don't use similar passwords for 3 consecutive transactions";
                }
                else
                {
                    var user = await this.context.Tblusers.FirstOrDefaultAsync(item => item.Username == username && item.Isactive == true);
                    if (user != null)
                    {
                        user.Password = password;
                        await this.context.SaveChangesAsync();
                        await UpdatePwdManager(username, password);
                        response.Result = "Pass";
                        response.message = "Password changed successfully";
                    }
                    else
                    {
                        response.Result = "Fail";
                        response.message = "Invalid OTP";
                    }
                }
            }
            return response;
        }
        //function to update the otpmanager
        public async Task UpdateOtp(string username, string otptext, string otptype)
        {
            var _otp = new Tblotpmanager()
            {
                Username = username,
                Otptext = otptext,
                Expiration = DateTime.Now.AddMinutes(30),
                CreateDate = DateTime.Now,
                Otptype = otptype

            };
            await this.context.Tblotpmanagers.AddAsync(_otp);
            await this.context.SaveChangesAsync();
        }

        //function for generatting the otp
        private string Generaterandomnumber()
        {
            Random random = new Random();
            string randomno = random.Next(0, 1000000).ToString("D6");
            return randomno;
        }
        //FUNCTION TO SEND TO THE USEREMAIL
        //private async Task SendOtpMail(string username, string useremail, string otptext)
        //{
        //    var mailrequest = new MailRequest();
        //    mailrequest.Email = useremail;
        //    mailrequest.Subject = "Thanks for Registering: OTP";
        //    mailrequest.EmailBody = GenerateEmailBody(username, otptext);
        //    await this.emailservice.SendEmail(mailrequest);
        //}

        //FUNCTION FOR GENERATING EMAILBODY
        //private string GenerateEmailBody(string name, string otptext)
        //{
        //    string emailbody = "<div style='width:100; background-color=grey'>";
        //    emailbody += "<h1>Hi" + name + ", Thanks for registering </h1>";
        //    emailbody += "<h2>OTPText is:" + otptext + "</h2>";
        //    emailbody += "</div>";
        //    return emailbody;
        //}

        //function to validate OTP
        public async Task<bool> ValidateOTP(string username, string OTPText)
        {
            bool response = false;
            var data = await this.context.Tblotpmanagers.FirstOrDefaultAsync(item => item.Username == username && item.Otptext == OTPText && item.Expiration > DateTime.Now);
            if (data != null)
            {
                response = true;
            }
            return response;
        }

        //function to update the password manager
        private async Task UpdatePwdManager(string username, string password)
        {
            var _opt = new Tblpwdmanager()
            {
                Username = username,
                Password = password,
                Modifydate = DateTime.Now
            };
            await this.context.Tblpwdmanagers.AddAsync(_opt);
            await this.context.SaveChangesAsync();
        }
        //function to validate the password history
        private async Task<bool> ValidatePWDHistory(string username, string password)
        {
            bool response = false;
            var pwd = await this.context.Tblpwdmanagers.Where(item => item.Username == username).
                OrderByDescending(p => p.Modifydate).Take(3).ToListAsync();
            if (pwd.Count > 0)
            {
                var validate = pwd.Where(o => o.Password == password);
                if (validate.Any())
                {
                    response = true;
                }
            }
            return response;
        }
        
        public async Task<APIResponse> UpdateRole(string username, string userrole)
        {
            APIResponse response = new APIResponse();
            var user = await this.context.Tblusers.FirstOrDefaultAsync(item => item.Username == username && item.Isactive == true);
            if (user != null)
            {
                user.Role = userrole;
                await this.context.SaveChangesAsync();
                response.Result = "Pass";
                response.message = "User status changed";
            }
            else
            {
                response.Result = "Failed";
                response.message = "Invalid user";
            }
            return response;
        }

        public async Task<APIResponse> UpdateStatus(string username, bool userstatus)
        {
            APIResponse response = new APIResponse();
            var user = await this.context.Tblusers.FirstOrDefaultAsync(item => item.Username == username);
            if (user != null)
            {
                user.Isactive = userstatus;
                await this.context.SaveChangesAsync();
                response.Result = "Pass";
                response.message = "User status changed";
            }
            else
            {
                response.Result = "Failed";
                response.message = "Invalid user";
            }
            return response;
        }

        public async Task<APIResponse> UserRegistration(UserRegister userRegister)
        {
            APIResponse response = new APIResponse();
            int userid = 0;
            bool isvalid = true;

            try
            {
                // duplicate user
                var _user = await this.context.Tblusers.Where(item => item.Username == userRegister.username).ToListAsync();
                if (_user.Count > 0)
                {
                    isvalid = false;
                    response.Result = "fail";
                    response.message = "Duplicate username";
                }

                // duplicate Email
                var _useremail = await this.context.Tblusers.Where(item => item.Email == userRegister.email).ToListAsync();
                if (_useremail.Count > 0)
                {
                    isvalid = false;
                    response.Result = "fail";
                    response.message = "Duplicate Email";
                }


                if (userRegister != null && isvalid)
                {
                    var _tempuser = new Tbltempuser()
                    {
                        Username = userRegister.username,
                        Fullname = userRegister.fullname,
                        Email = userRegister.email,
                        Password = userRegister.password,
                        Phone = userRegister.phone,
                        Gender = userRegister.gender,
                        Address = userRegister.address,
                        Role = userRegister.role,
                        Status = "Inactive"
                    };
                    await this.context.Tbltempusers.AddAsync(_tempuser);
                    await this.context.SaveChangesAsync();
                    userid = _tempuser.UserId;
                    string OTPText = Generaterandomnumber();
                    await UpdateOtp(userRegister.username, OTPText, "register");
                    //await SendOtpMail(userRegister.email, OTPText, userRegister.username);
                    response.Result = "pass";
                    response.message = userid.ToString();
                }

            }
            catch (Exception ex)
            {
                response.Result = "fail";
            }

            return response;
        }
    }
}
