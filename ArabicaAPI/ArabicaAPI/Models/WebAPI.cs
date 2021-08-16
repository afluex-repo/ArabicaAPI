using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace ArabicaAPI.Models
{
    public class WebAPI
    {
    }
    public class LoginModel
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
        public DataSet Login()
        {
            SqlParameter[] para ={new SqlParameter ("@UserName",LoginId),
                                new SqlParameter("@Password",Password)};
            DataSet ds = DBHelper.ExecuteQuery("CheckUserLoginForMobile", para);
            return ds;
        }
        public DataSet GetMemberName()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId) };
            DataSet ds = DBHelper.ExecuteQuery("GetMemberNameForMobile", para);
            return ds;
        }
        public DataSet GetMemberDetailForReInvestMent()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId) };
            DataSet ds = DBHelper.ExecuteQuery("SelectMemberDetailsForMobile", para);
            return ds;
        }
    }
    public class LoginResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string PK_UserId { get; set; }
        public string LoginId { get; set; }
        public string Fk_UserTypeId { get; set; }
        public string FullName { get; set; }
        public string Mobile { get; set; }
        public string UserType { get; set; }
        public string ProfilePic { get; set; }
        public string MyWalletBalance { get; set; }
    }
    public class Dashboard
    {
        public string PK_UserId { get; set; }
        public DataSet GetDashboard()
        {
            SqlParameter[] para = { new SqlParameter("@Fk_MemId", PK_UserId), };
            DataSet ds = DBHelper.ExecuteQuery("GetDashboardDetailsForMobile", para);
            return ds;
        }
    }
    public class DashboardResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string AllLeg1 { get; set; }
        public string AllLeg2 { get; set; }
        public string Total { get; set; }
        public string PermanentLeg1 { get; set; }
        public string PermanentLeg2 { get; set; }
        public string TotalPermanent { get; set; }
        public string Investment { get; set; }
        public string InactiveLeg1 { get; set; }
        public string InactiveLeg2 { get; set; }
        public string TotalInactive { get; set; }
        public string Product { get; set; }
        public string spname { get; set; }
        public string SPID { get; set; }
        public string Date { get; set; }
        public string RequestBy { get; set; }
        public string RequestByName { get; set; }
        public string Package { get; set; }
        public string TotalLeftBusiness { get; set; }
        public string TotalRightBusiness { get; set; }
        public string PaidBusiness { get; set; }
        public string CFL { get; set; }
        public string CFR { get; set; }
        public string MyDirect { get; set; }
        public string BinaryIncome { get; set; }
        public string TotalBinaryIncome { get; set; }
        public string DirectIncome { get; set; }
        public string TotalDirectIncome { get; set; }
        public string ROIIncome { get; set; }
        public string TotalROIIncome { get; set; }
        public string TotalTDS { get; set; }
        public string TDProfit { get; set; }
        public string Package1 { get; set; }
        public bool IsUpgrade { get; set; }
        public string PackageAmount400Percent { get; set; }
        public string BalanceTDProfit { get; set; }
        public bool IsUpgrade1 { get; set; }
        public string PackageAmount200Percent { get; set; }
        public string Coin { get; set; }
    }
    public class Package
    {
        public string PackageId { get; set; }
        public int Amount { get; set; }
        public DataSet GetPackage()
        {
            DataSet ds = DBHelper.ExecuteQuery("ProductDetailTopForMobile");
            return ds;
        }
        public DataSet GetProductDetailForReTopUp()
        {
            SqlParameter[] para = { new SqlParameter("@Amount", Amount), };
            DataSet ds = DBHelper.ExecuteQuery("ProductDetailReTopUpForMobile", para);
            return ds;
        }
    }

    public class PackageList
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<PackageResponse> lstPackage { get; set; }
    }
    public class PackageResponse
    {
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductId { get; set; }
    }

    public class ProductRequest
    {
        public string LoginId { get; set; }
        public string Status { get; set; }
        public DataSet GetProductBalance()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId),
            new SqlParameter("@Status", Status)
            };
            DataSet ds = DBHelper.ExecuteQuery("webPayoutAmountPinForMobile", para);
            return ds;
        }
    }
    public class ProductResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string ProductBalance { get; set; }
    }
    public class TopUpRequest
    {
        public string PK_UserId { get; set; }
        public string ProductId { get; set; }
        public string CreatedBy { get; set; }
        public DataSet TopUp()
        {
            SqlParameter[] para = { new SqlParameter("@FK_MemId", PK_UserId),
            new SqlParameter("@ProductId", ProductId),
            new SqlParameter("@CreatedBy", CreatedBy),
            };
            DataSet ds = DBHelper.ExecuteQuery("UpgradeIdbyWalletAmountForMobile", para);
            return ds;
        }
        public DataSet ReTopUp()
        {
            SqlParameter[] para = { new SqlParameter("@FK_MemId", PK_UserId),
            new SqlParameter("@ProductId", ProductId),
            new SqlParameter("@CreatedBy", CreatedBy),
            };
            DataSet ds = DBHelper.ExecuteQuery("UpgradeIdbyWalletAmountReTopUpForMobile", para);
            return ds;
        }
    }
    public class TopUpResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
        public string LoginId { get; set; }
        public string DisplayName { get; set; }
        public string PDetails { get; set; }
        public string Mobile1 { get; set; }
    }
    public class Profile
    {

        public string LoginId { get; set; }
        public DataSet GetProfile()
        {
            SqlParameter[] para = { new SqlParameter("@LoginId", LoginId), };
            DataSet ds = DBHelper.ExecuteQuery("GetAssociateListUpdateForMobile", para);
            return ds;
        }
    }
    public class ProfileResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string FK_MemId { get; set; }
        public string IsBlocked { get; set; }
        // public string LoginId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string JoiningDate { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string SponsorId { get; set; }
        public string PinCode { get; set; }
        public string SponsorName { get; set; }
        public string Address { get; set; }
        public string RefNo { get; set; }
        public string Date { get; set; }
        public string PS { get; set; }
        public string BS { get; set; }
        public string BLS { get; set; }
        public string BankAccName { get; set; }
        public string PanCard { get; set; }
        public string PanNo { get; set; }
        public string MemberAccNo { get; set; }
        public string MemberBranch { get; set; }
        public string IFSCCode { get; set; }
        public string AccountName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PK_StateId { get; set; }
        public string PK_CityId { get; set; }
        public string MemberStatus { get; set; }
        public string BlockCss { get; set; }
        public string PaytmId { get; set; }
    }
    public class UpdateProfile
    {
        public string FK_MemId { get; set; }
        public string Email { get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string IFSCCode { get; set; }
        public string BankHolderName { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
        public string FirstName { get; set; }
        public string PanNo { get; set; }
        public string UpdatedBy { get; set; }
        public string GooglePay { get; set; }
        public DataSet UpdateProfileUser()
        {
            SqlParameter[] para = {
                new SqlParameter("@PK_UserID",FK_MemId),
                new SqlParameter("@Email",Email),
                new SqlParameter("@AccountNo",AccountNo),
                new SqlParameter("@BankName",BankName),
                new SqlParameter("@IFSCCode",IFSCCode),
                new SqlParameter("@BankHolderName",BankHolderName),
                new SqlParameter("@Mobile1",MobileNo),
                new SqlParameter("@Address",Address),
                new SqlParameter("@State",State),
                new SqlParameter("@City",City),
                new SqlParameter("@PinCode",PinCode),
                new SqlParameter("@FirstName",FirstName),
                new SqlParameter("@PanNo",PanNo),
                new SqlParameter("@UpdatedBy",UpdatedBy),
                new SqlParameter("@GooglePay",GooglePay),
            };
            DataSet ds = DBHelper.ExecuteQuery("webMembersPIBIUpdateForMobile", para);
            return ds;
        }
    }
    public class UpdateProfileResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
    public class ChangePassword
    {
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string UpdatedBy { get; set; }
        public string Type { get; set; }
        public DataSet ChangePasword()
        {
            SqlParameter[] para = {
                new SqlParameter("@NewPassword",NewPassword),
                new SqlParameter("@OldPassword",OldPassword),
                new SqlParameter("@UpdatedBy",UpdatedBy),
                new SqlParameter("@PType",Type)
            };
            DataSet ds = DBHelper.ExecuteQuery("ChangePasswordForMobile", para);
            return ds;
        }
    }
    public class ChangePasswordResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string FK_MemId { get; set; }
        public string DisPlayName { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
    }
    public class Sponsor
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string FirstName { get; set; }
        public string DisplayName { get; set; }
        public string Fk_memId { get; set; }
        public string Fk_UserTypeId { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
    public class ValidateParent
    {
        public string SponsorCode { get; set; }
        public string Leg { get; set; }
        public DataSet CheckValidateParent()
        {
            SqlParameter[] para = {
                new SqlParameter("@SponsorCode",SponsorCode),
                new SqlParameter("@Leg",Leg),
            };
            DataSet ds = DBHelper.ExecuteQuery("MobileValidateParent", para);
            return ds;
        }
    }
    public class ValidateParentResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string FK_MemId { get; set; }
        public string DisplayName { get; set; }
    }

    public class SignUpModel
    {
        public string SponsorId { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Leg { get; set; }
        public string PanCard { get; set; }
        public string FK_ParentId { get; set; }
        public string FK_ProductId { get; set; }
        public DataSet SignUp()
        {
            SqlParameter[] para = {
                new SqlParameter("@SponserId",SponsorId),
                new SqlParameter("@Name",Name),
                  new SqlParameter("@MobileNo",MobileNo),
                new SqlParameter("@Leg",Leg),
                  new SqlParameter("@PanCard",PanCard),
                new SqlParameter("@FK_ParentId",FK_ParentId),
                new SqlParameter("@FK_ProductId",FK_ProductId)
            };
            DataSet ds = DBHelper.ExecuteQuery("AgentRegistrationForMobile", para);
            return ds;
        }
    }

    public class SignUpResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string MemId { get; set; }
        public string MSG { get; set; }
        public string LoginID { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string SponsorID { get; set; }
        public string Sponsorname { get; set; }
        public string MobileNO { get; set; }
        public string TransactionPassword { get; set; }
    }
    public class BinaryLevelIncomeModel
    {
        public string Fk_MemId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DataSet GetBinaryLevelIncome()
        {
            SqlParameter[] para = {
                new SqlParameter("@Fk_MemId",Fk_MemId),
                new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetBinaryLevelIncomeForMobile", para);
            return ds;
        }
    }
    public class BinaryLevelIncome
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<BinaryLevelIncomeResponse> lst { get; set; }
        public decimal Total { get; set; }
    }
    public class BinaryLevelIncomeResponse
    {
        public int SrNo { get; set; }
        public string Fk_MemId { get; set; }
        public string LoginID { get; set; }
        public string DisplayName { get; set; }
        public string CurrentDate { get; set; }
        public string Amount { get; set; }
        public string IncomeType { get; set; }
        public string BusinessAmount { get; set; }
        public string CommissionPercentage { get; set; }
    }
    public class LoanIncomeModel
    {
        public string Fk_MemId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DataSet LoanIncome()
        {
            SqlParameter[] para = {
                new SqlParameter("@Fk_MemId",Fk_MemId),
                new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("LoanIncomeForMobile", para);
            return ds;
        }
    }
    public class LoanIncome
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<LoanIncomeResponse> lst { get; set; }
        public decimal Total { get; set; }
    }
    public class LoanIncomeResponse
    {
        public int SrNo { get; set; }
        public string Fk_MemId { get; set; }
        public string LoginID { get; set; }
        public string DisplayName { get; set; }
        public string CurrentDate { get; set; }
        public string Amount { get; set; }
        public string IncomeType { get; set; }
        public string BusinessAmount { get; set; }
        public string CommissionPercentage { get; set; }
    }
    public class MemberDetail
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string TemPermanent { get; set; }
        public string JoiningDate { get; set; }
        public string LoginId { get; set; }
        public string MemId { get; set; }
        public string Password { get; set; }
        public string SponsorLoginId { get; set; }
        public string MemberName { get; set; }
        public string FatherName { get; set; }
        public string DisplayName { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string StateName { get; set; }
        public string Mobile1 { get; set; }
        public string Phone1 { get; set; }
        public string PanCard { get; set; }
        public string PanNo { get; set; }
        public string Fk_ProductId { get; set; }
        public string ProductAmount { get; set; }
        public string PaymentId { get; set; }
    }
    public class TeamRequest
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string LoginId { get; set; }
        public string Leg { get; set; }
        public string Down { get; set; }
        public string Status { get; set; }
        public DataSet GetMemberDownline()
        {
            SqlParameter[] para = {
                new SqlParameter("@FromDate",FromDate),
                new SqlParameter("@ToDate",ToDate),
                  new SqlParameter("@LoginId",LoginId),
                  new SqlParameter("@Leg",Leg),
                  new SqlParameter("@Down",Down),
                  new SqlParameter("@Status",Status),
            };
            DataSet ds = DBHelper.ExecuteQuery("MemberDownLineForMobile", para);
            return ds;
        }
    }
    public class TeamReponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Team> lst { get; set; }
    }
    public class Team
    {
        public string FK_MemId { get; set; }
        public string DisplayName { get; set; }
        public string LoginId { get; set; }
        public string JoiningDate { get; set; }
        public string Status { get; set; }
        public string Package { get; set; }
    }
    public class EWalletRequest
    {
        public int FormFK_Memid { get; set; }
        public int ToFK_Memid { get; set; }
        public float TransferredAmount { get; set; }
        public char TransferType { get; set; }
        public string Remark { get; set; }
        public string FormName { get; set; }
        public DataSet TransferFund()
        {
            SqlParameter[] para = {
                new SqlParameter("@FormFK_Memid",FormFK_Memid),
                new SqlParameter("@ToFK_Memid",ToFK_Memid),
                  new SqlParameter("@TransferredAmount",TransferredAmount),
                  new SqlParameter("@TransferType",TransferType),
                  new SqlParameter("@Remark",Remark),
                  new SqlParameter("@FormName",FormName),
            };
            DataSet ds = DBHelper.ExecuteQuery("TransFerFundUserPinWalletMobile", para);
            return ds;
        }
    }
    public class EWalletResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
    public class WalletRequest
    {
        public string FK_MemId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DataSet GetEWalletReport()
        {
            SqlParameter[] para = {
                new SqlParameter("@FK_MemId",FK_MemId),
                new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate),
            };
            DataSet ds = DBHelper.ExecuteQuery("GetDrCrDetailsEwalletMobile", para);
            return ds;
        }
    }
    public class WalletResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Wallet> lst { get; set; }
        public decimal TCrAmount { get; set; }
        public decimal TDrAmount { get; set; }
        public decimal Balance { get; set; }
    }
    public class Wallet
    {
        public int SrNo { get; set; }
        public string Id { get; set; }
        public string FK_MemId { get; set; }
        public string Status { get; set; }
        public string TransDate { get; set; }
        public string Narration { get; set; }
        public decimal DrAmount { get; set; }
        public decimal CrAmount { get; set; }
        public decimal Balance { get; set; }
    }
    public class ReferalTransactions
    {
        public string fk_memid { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DataSet GetReferalTransactions()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FK_MemId",fk_memid),
                 new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetRwalletDetailsForMobile", para);
            return ds;
        }
    }
    public class ReferalTransactionsList
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ReferalTransactionsResponse> lstReferalTransactions { get; set; }
        public decimal TotalCrAmount { get; set; }
        public decimal TotalDrAmount { get; set; }
    }
    public class ReferalTransactionsResponse
    {
        public int SrNo { get; set; }
        public string id { get; set; }
        public string fk_memid { get; set; }
        public string Status { get; set; }
        public string TransDate { get; set; }
        public string Narration { get; set; }
        public string DrAmount { get; set; }
        public string CrAmount { get; set; }
        public string Balance { get; set; }
    }
    public class BTranzactionDetails
    {
        public string fk_memid { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DataSet GetBTranzactionDetails()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FK_MemId",fk_memid),
                 new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetBwalletDetailsForMobile", para);
            return ds;
        }
    }
    public class BTranzactionDetailsList
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<BTranzactionDetailsResponse> lstBTranzactionDetails { get; set; }
        public decimal TotalCrAmount { get; set; }
        public decimal TotalDrAmount { get; set; }
    }
    public class BTranzactionDetailsResponse
    {
        public int SrNo { get; set; }
        public string id { get; set; }
        public string fk_memid { get; set; }
        public string Status { get; set; }
        public string TransDate { get; set; }
        public string Narration { get; set; }
        public string DrAmount { get; set; }
        public string CrAmount { get; set; }
        public string Balance { get; set; }
    }

    public class DTranzactionDetails
    {
        public string fk_memid { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DataSet GetDTranzactionDetails()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@FK_MemId",fk_memid),
                 new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate)
            };
            DataSet ds = DBHelper.ExecuteQuery("GetDwalletDetailsForMobile", para);
            return ds;
        }
    }
    public class DTranzactionDetailsList
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<DTranzactionDetailsResponse> lstDTranzactionDetails { get; set; }
        public decimal TotalCrAmount { get; set; }
        public decimal TotalDrAmount { get; set; }
    }
    public class DTranzactionDetailsResponse
    {
        public int SrNo { get; set; }
        public string id { get; set; }
        public string fk_memid { get; set; }
        public string Status { get; set; }
        public string TransDate { get; set; }
        public string Narration { get; set; }
        public string DrAmount { get; set; }
        public string CrAmount { get; set; }
        public string Balance { get; set; }
    }
    public class DirectIncome
    {
        public string Fk_MemId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public DataSet GetDirectIncome()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@Fk_MemId",Fk_MemId),
                 new SqlParameter("@FromDate",FromDate),
                  new SqlParameter("@ToDate",ToDate),

            };
            DataSet ds = DBHelper.ExecuteQuery("DirectIncomeForMobile", para);
            return ds;
        }
    }
    public class DirectIncomeList
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<DirectIncomeResponse> lstDirectIncome { get; set; }
        public decimal Total { get; set; }
    }
    public class DirectIncomeResponse
    {
        public int SrNo { get; set; }
        public string LoginId { get; set; }
        public string DisplayName { get; set; }
        public string CurrentDate { get; set; }
        public string Amount { get; set; }
        public string IncomeType { get; set; }
        public string BusinessAmount { get; set; }
        public string CommissionPercentage { get; set; }
    }
    public class ForgetPassword
    {
        public string LoginId { get; set; }
        public string Mobile1 { get; set; }
        public DataSet GetForgetPassword()
        {
            SqlParameter[] para =
            {
                  new SqlParameter("@LoginID",LoginId),
                  new SqlParameter("@Mobile",Mobile1)

            };
            DataSet ds = DBHelper.ExecuteQuery("WebResetPasswordForMobile", para);
            return ds;
        }
    }
    public class ForgetPasswordList
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ForgetPasswordResponse> lsForgetPassword { get; set; }
    }
    public class ForgetPasswordResponse
    {
        public string LoginId { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Mobile1 { get; set; }


    }
    public class TreeRequest
    {
        public string LoginId { get; set; }
        public string LoginIdParent { get; set; }
        public DataSet GetTreeData()
        {
            SqlParameter[] para =
            {
                 new SqlParameter("@LoginId",LoginId),
                  new SqlParameter("@LoginIdParent",LoginIdParent),
            };
            DataSet ds = DBHelper.ExecuteQuery("ShowMemberTreeForMobile", para);
            return ds;
        }
    }
    public class TreeResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<Tree> lst { get; set; }
        public List<TreeDetails> lstDetails { get; set; }
    }
    public class Tree
    {
        public string FK_MemId { get; set; }
        public string ParentId { get; set; }
        public string SponsorId { get; set; }
        public string LoginId { get; set; }
        public string MemberName { get; set; }
        public string TemPermanent { get; set; }
        public string Leg { get; set; }
        public string MemberLevel { get; set; }
        public string PackageName { get; set; }
        public decimal Amount { get; set; }
        public string SpillById { get; set; }
        public string ImageUrl { get; set; }
        public string PBV { get; set; }
    }
    public class TreeDetails
    {
        public string LoginId { get; set; }
        public string FK_MemId { get; set; }
        public string DisplayName { get; set; }
        public string JoiningDate { get; set; }
        public string PermanentDate { get; set; }
        public string Status { get; set; }
        public string SponsorId { get; set; }
        public string SponsorName { get; set; }
        public string ParentId { get; set; }
        public string ParentName { get; set; }
        public string ProductName { get; set; }
        public string ReferralRegisteredLeft { get; set; }
        public string ReferralRegisteredRight { get; set; }
        public string ReferralConfirmedLeft { get; set; }
        public string ReferralConfirmedRight { get; set; }
        public string AssociatesRegisteredLeft { get; set; }
        public string AssociatesRegisteredRight { get; set; }
        public string AssociatesConfirmedLeft { get; set; }
        public string AssociatesConfirmedRight { get; set; }
        public string TotalLeft { get; set; }
        public string TotalRight { get; set; }
        public string TotalPair { get; set; }
        public string AllLeft { get; set; }
        public string AllRight { get; set; }
        public string UsedLeft { get; set; }
        public string UsedRight { get; set; }
        public string UsedPair { get; set; }
        public string CurrentLeft { get; set; }
        public string CurrentRight { get; set; }
        public string CurrentPair { get; set; }
        public string PermanentLeft { get; set; }
        public string PermanentRight { get; set; }
        public string PinAmount { get; set; }
        public string TopUpPinAmount { get; set; }
        public string PendingPayment { get; set; }
        public string PBV { get; set; }
        public string TemPermanent { get; set; }
        public string LeftBooking { get; set; }
        public string RightBooking { get; set; }
        public string TotalBooking { get; set; }
        public string LeftAllotment { get; set; }
        public string RightAllotment { get; set; }
        public string TotalAllotment { get; set; }
        public string SelfBooking { get; set; }
        public string SelfAllotment { get; set; }
        public string SelfBusiness { get; set; }
        public string PlotNo { get; set; }
        public string SiteName { get; set; }
    }
    public class TreeAPI
    {
        public List<MyTree> GetGenelogy { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public string LoginId { get; set; }
        public string Fk_headId { get; set; }
        public DataSet GetTree()
        {
            SqlParameter[] para = {   new SqlParameter("@LoginId", LoginId),
                 new SqlParameter("@Fk_headId", Fk_headId)
                                  };

            DataSet ds = DBHelper.ExecuteQuery("GetTree", para);
            return ds;
        }
    }

    public class MyTree
    {
        public string Fk_UserId { get; set; }
        public string SponsorId { get; set; }
        public string Fk_ParentId { get; set; }
        public string TeamPermanent { get; set; }
        public string LoginId { get; set; }
        public string Fk_SponsorId { get; set; }
        public string MemberName { get; set; }
        public string MemberLevel { get; set; }

        public string Id { get; set; }
        public string Leg { get; set; }

        public string ActivationDate { get; set; }
        public string ActiveLeft { get; set; }
        public string ActiveRight { get; set; }
        public string InactiveLeft { get; set; }
        public string InactiveRight { get; set; }
        public string BusinessLeft { get; set; }
        public string BusinessRight { get; set; }
        public string TotalBusiness { get; set; }
        public string ImageURL { get; set; }
        public string TopUpAmount { get; set; }
    }
}
