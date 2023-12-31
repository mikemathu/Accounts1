using Accounts.Dtos;
<<<<<<< HEAD
using Accounts.Dtos.Banks;
using Accounts.Models;
using Accounts.Models.Banks;
=======
using Accounts.Dtos.Payment_Modes;
using Accounts.Models;
using Accounts.Models.Payment_Modes;
>>>>>>> f04513da27eb886490b2efca930f26d1001200be
using Accounts.Models.VM;
using AutoMapper;

namespace PlatformService.Profiles
{
    public class GeneralLedgerAccountsProfile : Profile
    {
        public GeneralLedgerAccountsProfile()
        {
            // Source -> Target
            CreateMap<FiscalPeriodVM, FiscalPeriod>();
            CreateMap<AccountDetailVM, AccountDetail>();

            //GeneralLedgerAccounts
            CreateMap<ReadAccountDetailsDto, AccountDetail>().ReverseMap();
            CreateMap<ReadAllAccountsDto, AccountDetail>().ReverseMap();
            CreateMap<ReadAllAccountsDto, AccountDetail>().ReverseMap();
            CreateMap<AccountDetail, CreateUpdateAccountReadDto>().ReverseMap();
            CreateMap<AccountClass, ReadAccountClassDto2>().ReverseMap();
            CreateMap<SubAccountDetail, ReadSubAccountDetailsDto>().ReverseMap();
            CreateMap<CashFlowCategory, ReadCashFlowCategoryDto>().ReverseMap();
            //CreateMap<AccountDetail, ReadAccountDetailsListDto>().ReverseMap();
            CreateMap<CreateUpdateAccountDto, AccountDetail>();
            CreateMap<CashFlowCategory, ReadCashFlowCategoryDto>().ReverseMap();
            CreateMap<CreateUpdateSubAccountDto, SubAccountDetail>().ReverseMap();
            CreateMap<CreateUpdateCashFlowCategoryDto, CashFlowCategory>().ReverseMap();


<<<<<<< HEAD
            //Banks
            CreateMap<Bank, ReadAllBankDto>().ReverseMap();
            CreateMap<Bank, ReadBankDetailsDto>().ReverseMap();
            CreateMap<Bank, CreateUpdateBankReadDto>().ReverseMap();
=======
            //Payment Details 
            CreateMap<PaymentMode, ReadAllPaymentModesDto>().ReverseMap();

>>>>>>> f04513da27eb886490b2efca930f26d1001200be

        }
    }
}