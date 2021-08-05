using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ArabicaAPI.Models;
using System.Data;

namespace ArabicaAPI.Controllers
{
    public class WebAPIController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage UserLogin(LoginModel model)
        {
            LoginResponse obj = new LoginResponse();
            try
            {
                DataSet ds = model.Login();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj.Status = "0";
                    obj.Message = "Successfully logged in";
                    obj.PK_UserId = ds.Tables[0].Rows[0]["Pk_userId"].ToString();
                    obj.UserType = ds.Tables[0].Rows[0]["UserType"].ToString();
                    obj.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                    obj.FullName = ds.Tables[0].Rows[0]["FullName"].ToString();
                    obj.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    obj.MyWalletBalance = ds.Tables[0].Rows[0]["MyWalletBalance"].ToString();
                    obj.Fk_UserTypeId = ds.Tables[0].Rows[0]["Fk_UserTypeId"].ToString();
                    obj.ProfilePic = ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                }
                else
                {
                    obj.Status = "1";
                    obj.Message = "Incorrect Login Id or Password";
                }
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }
        [HttpPost]
        public HttpResponseMessage DashBoard(Dashboard obj)
        {
            DashboardResponse model = new DashboardResponse();
            try
            {
                DataSet ds = obj.GetDashboard();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    model.Status = "0";
                    model.Message = "Record Found";
                    model.AllLeg1 = ds.Tables[0].Rows[0]["AllLeg1"].ToString();
                    model.AllLeg2 = ds.Tables[0].Rows[0]["AllLeg2"].ToString();
                    model.Total = ds.Tables[0].Rows[0]["Total"].ToString();
                    model.PermanentLeg1 = ds.Tables[0].Rows[0]["PermanentLeg1"].ToString();
                    model.PermanentLeg2 = ds.Tables[0].Rows[0]["PermanentLeg2"].ToString();
                    model.TotalPermanent = ds.Tables[0].Rows[0]["TotalPermanent"].ToString();
                    model.Investment = ds.Tables[0].Rows[0]["Investment"].ToString();
                    model.InactiveLeg1 = ds.Tables[0].Rows[0]["InactiveLeg1"].ToString();
                    model.InactiveLeg2 = ds.Tables[0].Rows[0]["InactiveLeg2"].ToString();
                    model.TotalInactive = ds.Tables[0].Rows[0]["TotalInactive"].ToString();
                    model.Product = ds.Tables[0].Rows[0]["Product"].ToString();
                    model.spname = ds.Tables[0].Rows[0]["spname"].ToString();
                    model.SPID = ds.Tables[0].Rows[0]["SPID"].ToString();
                    model.Date = ds.Tables[0].Rows[0]["Date"].ToString();
                    model.RequestBy = ds.Tables[0].Rows[0]["RequestBy"].ToString();
                    model.RequestByName = ds.Tables[0].Rows[0]["RequestByName"].ToString();
                    model.Package = ds.Tables[0].Rows[0]["Package"].ToString();
                    model.TotalLeftBusiness = ds.Tables[0].Rows[0]["TotalLeftBusiness"].ToString();
                    model.TotalRightBusiness = ds.Tables[0].Rows[0]["TotalRightBusiness"].ToString();
                    model.PaidBusiness = ds.Tables[0].Rows[0]["PaidBusiness"].ToString();
                    model.CFL = ds.Tables[0].Rows[0]["CFL"].ToString();
                    model.CFR = ds.Tables[0].Rows[0]["CFR"].ToString();

                    model.MyDirect = ds.Tables[1].Rows[0]["MyDirect"].ToString();
                    model.BinaryIncome = ds.Tables[1].Rows[0]["BinaryIncome"].ToString();
                    model.TotalBinaryIncome = ds.Tables[1].Rows[0]["TotalBinaryIncome"].ToString();
                    model.DirectIncome = ds.Tables[1].Rows[0]["DirectIncome"].ToString();
                    model.TotalDirectIncome = ds.Tables[1].Rows[0]["TotalDirectIncome"].ToString();
                    model.ROIIncome = ds.Tables[1].Rows[0]["ROIIncome"].ToString();
                    model.TotalROIIncome = ds.Tables[1].Rows[0]["TotalROIIncome"].ToString();
                    model.TotalTDS = ds.Tables[1].Rows[0]["TotalTDS"].ToString();

                    model.TDProfit = ds.Tables[2].Rows[0]["TDProfit"].ToString();
                    model.Package = ds.Tables[3].Rows[0]["Package"].ToString();
                    model.IsUpgrade = Convert.ToBoolean(ds.Tables[4].Rows[0]["IsUpgrade"]);
                    model.PackageAmount400Percent = ds.Tables[4].Rows[0]["PackageAmount400Percent"].ToString();
                    model.BalanceTDProfit = ds.Tables[5].Rows[0]["BalanceTDProfit"].ToString();
                    model.IsUpgrade1 = Convert.ToBoolean(ds.Tables[6].Rows[0]["IsUpgrade"]);
                    model.PackageAmount200Percent = ds.Tables[6].Rows[0]["PackageAmount200Percent"].ToString();
                    model.Coin = ds.Tables[7].Rows[0]["Coin"].ToString();
                }
                else
                {
                    model.Status = "1";
                    model.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public HttpResponseMessage Profile(Profile obj)
        {
            ProfileResponse model = new ProfileResponse();
            try
            {
                DataSet ds = obj.GetProfile();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    model.Status = "0";
                    model.Message = "Record Found";
                    model.FK_MemId = ds.Tables[0].Rows[0]["FK_MemId"].ToString();
                    model.IsBlocked = ds.Tables[0].Rows[0]["IsBlocked"].ToString();
                    //  model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                    model.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                    model.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    model.JoiningDate = ds.Tables[0].Rows[0]["JoiningDate"].ToString();
                    model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                    model.SponsorId = ds.Tables[0].Rows[0]["SponsorId"].ToString();
                    model.PinCode = ds.Tables[0].Rows[0]["PinCode"].ToString();
                    model.SponsorName = ds.Tables[0].Rows[0]["SponsorName"].ToString();
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                    model.RefNo = ds.Tables[0].Rows[0]["RefNo"].ToString();
                    model.Date = ds.Tables[0].Rows[0]["Date"].ToString();
                    model.PS = ds.Tables[0].Rows[0]["PS"].ToString();
                    model.BS = ds.Tables[0].Rows[0]["BS"].ToString();
                    model.BLS = ds.Tables[0].Rows[0]["BLS"].ToString();
                    model.BankAccName = ds.Tables[0].Rows[0]["BankAccName"].ToString();
                    model.PanCard = ds.Tables[0].Rows[0]["PanCard"].ToString();
                    model.PanNo = ds.Tables[0].Rows[0]["PanNo"].ToString();
                    model.MemberAccNo = ds.Tables[0].Rows[0]["MemberAccNo"].ToString();
                    model.MemberBranch = ds.Tables[0].Rows[0]["MemberBranch"].ToString();
                    model.IFSCCode = ds.Tables[0].Rows[0]["IFSCCode"].ToString();
                    model.AccountName = ds.Tables[0].Rows[0]["AccountName"].ToString();
                    model.State = ds.Tables[0].Rows[0]["State"].ToString();
                    model.City = ds.Tables[0].Rows[0]["City"].ToString();
                    model.PK_StateId = ds.Tables[0].Rows[0]["PK_StateId"].ToString();
                    model.PK_CityId = ds.Tables[0].Rows[0]["PK_CityId"].ToString();
                    model.MemberStatus = ds.Tables[0].Rows[0]["MemberStatus"].ToString();
                    model.BlockCss = ds.Tables[0].Rows[0]["BlockCss"].ToString();
                    model.PaytmId = ds.Tables[0].Rows[0]["PaytmId"].ToString();
                }
                else
                {
                    model.Status = "1";
                    model.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpPost]
        public HttpResponseMessage GetProduct(Package model)
        {
            PackageList obj1 = new PackageList();
            List<PackageResponse> lst = new List<PackageResponse>();
            try
            {
                DataSet ds = model.GetPackage();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj1.Status = "0";
                    obj1.Message = "Record Found";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        PackageResponse obj = new PackageResponse();
                        obj.ProductId = r["pk_productid"].ToString();
                        obj.ProductPrice = r["ProductPrice"].ToString();
                        obj.ProductName = r["ProductName"].ToString();
                        lst.Add(obj);
                    }
                    obj1.lstPackage = lst;
                }
                else
                {
                    obj1.Status = "1";
                    obj1.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                obj1.Status = "1";
                obj1.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, obj1);
        }
        [HttpPost]
        public HttpResponseMessage GetProductBalance(ProductRequest obj)
        {
            ProductResponse model = new ProductResponse();
            try
            {
                DataSet ds = obj.GetProductBalance();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Status = "0";
                    model.Message = "Record Found";
                    model.ProductBalance = ds.Tables[0].Rows[0]["BalanceAmount"].ToString();
                }
                else
                {
                    model.Status = "1";
                    model.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public HttpResponseMessage TopUp(TopUpRequest obj)
        {
            TopUpResponse model = new TopUpResponse();
            try
            {
                DataSet ds = obj.TopUp();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "1")
                    {
                        model.Status = "0";
                        model.Message = "Top-up suceessfully";
                        model.Result = ds.Tables[0].Rows[0]["Result"].ToString();
                        model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        model.DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                        model.PDetails = ds.Tables[0].Rows[0]["PDetails"].ToString();
                        model.Mobile1 = ds.Tables[0].Rows[0]["Mobile1"].ToString();
                    }
                }
                else
                {
                    model.Status = "1";
                    model.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public HttpResponseMessage ChangePassword(ChangePassword obj)
        {
            ChangePasswordResponse model = new ChangePasswordResponse();
            try
            {
                DataSet ds = obj.ChangePasword();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Code"].ToString() == "1")
                    {
                        model.Status = "0";
                        model.Message = ds.Tables[0].Rows[0]["Remark"].ToString();
                        model.FK_MemId = ds.Tables[0].Rows[0]["FK_MemId"].ToString();
                        model.DisPlayName = ds.Tables[0].Rows[0]["DisPlayName"].ToString();
                        model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                        model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                        model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                    }
                    else
                    {
                        model.Status = "1";
                        model.Message = ds.Tables[0].Rows[0]["Remark"].ToString();
                    }
                }
                else
                {
                    model.Status = "1";
                    model.Message = "Password not changed";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public HttpResponseMessage GetMemberName(LoginModel obj)
        {
            Sponsor model = new Sponsor();
            try
            {
                DataSet ds = obj.GetMemberName();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Msg"].ToString() == "0")
                    {
                        model.Status = "0";
                        model.Message = ds.Tables[0].Rows[0]["Remark"].ToString();
                        model.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                        model.DisplayName = ds.Tables[0].Rows[0]["DisPlayName"].ToString();
                        model.Fk_memId = ds.Tables[0].Rows[0]["Fk_memId"].ToString();
                        model.Fk_UserTypeId = ds.Tables[0].Rows[0]["Fk_UserTypeId"].ToString();
                        model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                        model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                    }
                    else
                    {
                        model.Status = "1";
                        model.Message = ds.Tables[0].Rows[0]["Remark"].ToString();
                    }
                }
                else
                {
                    model.Status = "1";
                    model.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public HttpResponseMessage ValidateParent(ValidateParent obj)
        {
            ValidateParentResponse model = new ValidateParentResponse();
            try
            {
                DataSet ds = obj.CheckValidateParent();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        model.Status = "1";
                        model.Message = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                    }
                    else
                    {
                        model.Status = "0";
                        model.Message = "Valid";
                        model.FK_MemId = ds.Tables[0].Rows[0]["FK_MemId"].ToString();
                        model.DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                    }
                }
                else
                {
                    model.Status = "1";
                    model.Message = "Invalid";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpPost]
        public HttpResponseMessage SignUp(SignUpModel obj)
        {
            SignUpResponse model = new SignUpResponse();
            try
            {
                DataSet ds = obj.SignUp();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Status = "0";
                    model.Message = "Registered Successfully";
                    model.MemId = ds.Tables[0].Rows[0]["MemId"].ToString();
                    model.MSG = ds.Tables[0].Rows[0]["MSG"].ToString();
                    model.LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                    model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                    model.DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                    model.SponsorID = ds.Tables[0].Rows[0]["SponsorID"].ToString();
                    model.Sponsorname = ds.Tables[0].Rows[0]["Sponsorname"].ToString();
                    model.MobileNO = ds.Tables[0].Rows[0]["MobileNO"].ToString();
                    model.TransactionPassword = ds.Tables[0].Rows[0]["TransactionPassword"].ToString();
                }
                else
                {
                    model.Status = "1";
                    model.Message = "Error occured";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public HttpResponseMessage BinaryLevelIncome(BinaryLevelIncomeModel obj)
        {
            BinaryLevelIncome model = new BinaryLevelIncome();
            List<BinaryLevelIncomeResponse> lst = new List<BinaryLevelIncomeResponse>();
            try
            {
                DataSet ds = obj.GetBinaryLevelIncome();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Status = "0";
                    model.Message = "Record Found";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        BinaryLevelIncomeResponse obj1 = new BinaryLevelIncomeResponse();
                        obj1.Fk_MemId = ds.Tables[0].Rows[0]["Fk_MemId"].ToString();
                        obj1.LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                        obj1.DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                        obj1.CurrentDate = ds.Tables[0].Rows[0]["CurrentDate"].ToString();
                        obj1.Amount = ds.Tables[0].Rows[0]["Amount"].ToString();
                        obj1.IncomeType = ds.Tables[0].Rows[0]["IncomeType"].ToString();
                        obj1.BusinessAmount = ds.Tables[0].Rows[0]["BusinessAmount"].ToString();
                        obj1.CommissionPercentage = ds.Tables[0].Rows[0]["CommissionPercentage"].ToString();
                        lst.Add(obj1);
                    }
                    model.lst = lst;
                }
                else
                {
                    model.Status = "1";
                    model.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public HttpResponseMessage GetLoanIncome(LoanIncomeModel obj)
        {
            LoanIncome model = new LoanIncome();
            List<LoanIncomeResponse> lst = new List<LoanIncomeResponse>();
            try
            {
                DataSet ds = obj.LoanIncome();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Status = "0";
                    model.Message = "Valid";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        LoanIncomeResponse obj1 = new LoanIncomeResponse();
                        obj1.Fk_MemId = ds.Tables[0].Rows[0]["Fk_MemId"].ToString();
                        obj1.LoginID = ds.Tables[0].Rows[0]["LoginID"].ToString();
                        obj1.DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                        obj1.CurrentDate = ds.Tables[0].Rows[0]["CurrentDate"].ToString();
                        obj1.Amount = ds.Tables[0].Rows[0]["Amount"].ToString();
                        obj1.IncomeType = ds.Tables[0].Rows[0]["IncomeType"].ToString();
                        obj1.BusinessAmount = ds.Tables[0].Rows[0]["BusinessAmount"].ToString();
                        obj1.CommissionPercentage = ds.Tables[0].Rows[0]["CommissionPercentage"].ToString();
                        lst.Add(obj1);
                    }
                    model.lst = lst;
                }
                else
                {
                    model.Status = "1";
                    model.Message = "Invalid";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public HttpResponseMessage GetProductForReInvestment(Package model)
        {
            PackageList obj1 = new PackageList();
            List<PackageResponse> lst = new List<PackageResponse>();
            try
            {
                DataSet ds = model.GetProductDetailForReTopUp();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj1.Status = "0";
                    obj1.Message = "Record Found";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        PackageResponse obj = new PackageResponse();
                        obj.ProductId = r["pk_productid"].ToString();
                        obj.ProductPrice = r["ProductPrice"].ToString();
                        obj.ProductName = r["ProductName"].ToString();
                        lst.Add(obj);
                    }
                    obj1.lstPackage = lst;
                }
                else
                {
                    obj1.Status = "1";
                    obj1.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                obj1.Status = "1";
                obj1.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, obj1);
        }
        [HttpPost]
        public HttpResponseMessage GetMemberDetail(LoginModel model)
        {
            MemberDetail obj = new MemberDetail();
            try
            {
                DataSet ds = model.GetMemberDetailForReInvestMent();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj.Status = "0";
                    obj.Message = "Record Found";
                    obj.TemPermanent = ds.Tables[0].Rows[0]["TemPermanent"].ToString();
                    obj.JoiningDate = ds.Tables[0].Rows[0]["JoiningDate"].ToString();
                    obj.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                    obj.MemId = ds.Tables[0].Rows[0]["MemId"].ToString();
                    obj.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                    obj.SponsorLoginId = ds.Tables[0].Rows[0]["SponsorLoginId"].ToString();
                    obj.MemberName = ds.Tables[0].Rows[0]["MemberName"].ToString();
                    obj.FatherName = ds.Tables[0].Rows[0]["FathersName"].ToString();
                    obj.DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                    obj.Address1 = ds.Tables[0].Rows[0]["Address1"].ToString();
                    obj.City = ds.Tables[0].Rows[0]["City"].ToString();
                    obj.StateName = ds.Tables[0].Rows[0]["StateName"].ToString();
                    obj.Mobile1 = ds.Tables[0].Rows[0]["Mobile1"].ToString();
                    obj.Phone1 = ds.Tables[0].Rows[0]["Phone1"].ToString();
                    obj.PanNo = ds.Tables[0].Rows[0]["PanNo"].ToString();
                    obj.Fk_ProductId = ds.Tables[0].Rows[0]["FK_ProductId"].ToString();
                    obj.ProductAmount = ds.Tables[0].Rows[0]["ProductAmount"].ToString();
                    obj.PaymentId = ds.Tables[0].Rows[0]["PaymentId"].ToString();
                }
                else
                {
                    obj.Status = "1";
                    obj.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                obj.Status = "1";
                obj.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, obj);
        }
        public HttpResponseMessage ReInvestment(TopUpRequest obj)
        {
            TopUpResponse model = new TopUpResponse();
            try
            {
                DataSet ds = obj.ReTopUp();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0][0].ToString() == "1")
                    {
                        model.Status = "0";
                        model.Message = "Re Top-Up successfully";
                        model.Result = ds.Tables[0].Rows[0]["Result"].ToString();
                        model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                        model.DisplayName = ds.Tables[0].Rows[0]["DisplayName"].ToString();
                        model.PDetails = ds.Tables[0].Rows[0]["PDetails"].ToString();
                        model.Mobile1 = ds.Tables[0].Rows[0]["Mobile1"].ToString();
                    }
                    else
                    {
                        model.Status = "1";
                        model.Message = "Error occurred";
                    }
                }
                else
                {
                    model.Status = "1";
                    model.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                model.Status = "1";
                model.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
        [HttpPost]
        public HttpResponseMessage GetReferalWallet(ReferalTransactions model)
        {
            ReferalTransactionsList obj1 = new ReferalTransactionsList();
            List<ReferalTransactionsResponse> lst = new List<ReferalTransactionsResponse>();
            try
            {
                DataSet ds = model.GetReferalTransactions();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj1.Status = "0";
                    obj1.Message = "Record Found";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        ReferalTransactionsResponse obj = new ReferalTransactionsResponse();
                        obj.id = r["id"].ToString();
                        obj.fk_memid = r["fk_memid"].ToString();
                        obj.Status = r["Status"].ToString();
                        obj.TransDate = r["TransDate"].ToString();
                        obj.Narration = r["Narration"].ToString();
                        obj.DrAmount = r["DrAmount"].ToString();
                        obj.CrAmount = r["CrAmount"].ToString();
                        obj.Balance = r["Balance"].ToString();
                        lst.Add(obj);
                    }
                    obj1.lstReferalTransactions = lst;
                }
                else
                {
                    obj1.Status = "1";
                    obj1.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                obj1.Status = "1";
                obj1.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, obj1);
        }
        [HttpPost]
        public HttpResponseMessage GetBinaryWallet(BTranzactionDetails model)
        {
            BTranzactionDetailsList obj1 = new BTranzactionDetailsList();
            List<BTranzactionDetailsResponse> lst = new List<BTranzactionDetailsResponse>();
            try
            {
                DataSet ds = model.GetBTranzactionDetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj1.Status = "0";
                    obj1.Message = "Record Found";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        BTranzactionDetailsResponse obj = new BTranzactionDetailsResponse();
                        obj.id = r["id"].ToString();
                        obj.fk_memid = r["fk_memid"].ToString();
                        obj.Status = r["Status"].ToString();
                        obj.TransDate = r["TransDate"].ToString();
                        obj.Narration = r["Narration"].ToString();
                        obj.DrAmount = r["DrAmount"].ToString();
                        obj.CrAmount = r["CrAmount"].ToString();
                        obj.Balance = r["Balance"].ToString();
                        lst.Add(obj);
                    }
                    obj1.lstBTranzactionDetails = lst;
                }
                else
                {
                    obj1.Status = "1";
                    obj1.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                obj1.Status = "1";
                obj1.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, obj1);
        }
        [HttpPost]
        public HttpResponseMessage RoiWallet(DTranzactionDetails model)
        {
            DTranzactionDetailsList obj1 = new DTranzactionDetailsList();
            List<DTranzactionDetailsResponse> lst = new List<DTranzactionDetailsResponse>();
            try
            {
                DataSet ds = model.GetDTranzactionDetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj1.Status = "0";
                    obj1.Message = "Record Found";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        DTranzactionDetailsResponse obj = new DTranzactionDetailsResponse();
                        obj.id = r["id"].ToString();
                        obj.fk_memid = r["fk_memid"].ToString();
                        obj.Status = r["Status"].ToString();
                        obj.TransDate = r["TransDate"].ToString();
                        obj.Narration = r["Narration"].ToString();
                        obj.DrAmount = r["DrAmount"].ToString();
                        obj.CrAmount = r["CrAmount"].ToString();
                        obj.Balance = r["Balance"].ToString();
                        lst.Add(obj);
                    }
                    obj1.lstDTranzactionDetails = lst;
                }
                else
                {
                    obj1.Status = "1";
                    obj1.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                obj1.Status = "1";
                obj1.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, obj1);
        }


        [HttpPost]
        public HttpResponseMessage DirectIncome(DirectIncome model)
        {
            DirectIncomeList obj1 = new DirectIncomeList();
            List<DirectIncomeResponse> lst = new List<DirectIncomeResponse>();
            try
            {
                DataSet ds = model.GetDirectIncome();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj1.Status = "0";
                    obj1.Message = "Record Found";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        DirectIncomeResponse obj = new DirectIncomeResponse();
                        obj.fk_memid = r["fk_memid"].ToString();
                        obj.Status = r["Status"].ToString();
                        obj.CalculationAmt = r["CalculationAmt"].ToString();
                        obj.Leg = r["Leg"].ToString();
                        obj.CreatedDate = r["CreatedDate"].ToString();
                        obj.JoiningDate = r["JoiningDate"].ToString();
                        obj.DisplayName = r["DisplayName"].ToString();
                        lst.Add(obj);
                    }
                    obj1.lstDirectIncome = lst;
                }
                else
                {
                    obj1.Status = "1";
                    obj1.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                obj1.Status = "1";
                obj1.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, obj1);
        }


        [HttpPost]
        public HttpResponseMessage ForgetPassword(ForgetPassword model)
        {
            ForgetPasswordList obj1 = new ForgetPasswordList();
            List<ForgetPasswordResponse> lst = new List<ForgetPasswordResponse>();
            try
            {
                DataSet ds = model.GetForgetPassword();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    obj1.Status = "0";
                    obj1.Message = "Record Found";
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        ForgetPasswordResponse obj = new ForgetPasswordResponse();
                        obj.LoginId = r["LoginId"].ToString();
                        obj.Mobile1 = r["Mobile1"].ToString();
                        obj.DisplayName = r["DisplayName"].ToString();
                        obj.Password = r["Password"].ToString();
                        lst.Add(obj);
                    }
                    obj1.lsForgetPassword = lst;
                }
                else
                {
                    obj1.Status = "1";
                    obj1.Message = "No Record Found";
                }
            }
            catch (Exception ex)
            {
                obj1.Status = "1";
                obj1.Message = ex.Message;
            }
            return Request.CreateResponse(HttpStatusCode.OK, obj1);
        }
    }
}
