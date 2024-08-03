using App.Core.CommonModel;
using App.Core.Dtos.Invoices;
using App.Core.Model.OperationModule;
using App.Core.Model.SetupModule;
using App.Core.ViewModel.OperationModule;
using App.Core.ViewModel.SetupModule;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.AutoMapperConfigurations
{
    public class MappingsProfile : Profile
    {
        public override string ProfileName => "MappingsProfile";

        public MappingsProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<SupplierViewModel, Supplier>();

            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<Item, ItemViewModel>();
            CreateMap<ItemViewModel, Item>();

            CreateMap<Unit, UnitViewModel>();
            CreateMap<UnitViewModel, Unit>();

            CreateMap<Purchasemuster, PurchasemusterViewModel>()
                .ForMember(vm => vm.Date,
                   opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.Date)));


            CreateMap<PurchasemusterViewModel, Purchasemuster>()
                .ForMember(dto => dto.Date,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.Date)));

            CreateMap<Purchasedetail, PurchasedetailViewModel>();
            CreateMap<PurchasedetailViewModel, Purchasedetail>();

            CreateMap<Sale, SaleViewModel>()
                .ForMember(vm => vm.Date,
                   opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.Date)));

            CreateMap<SaleViewModel, Sale>()
                .ForMember(dto => dto.Date,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.Date)));

            CreateMap<Salesdetail, SalesdetailViewModel>();
            CreateMap<SalesdetailViewModel, Salesdetail>();

            CreateMap<Invoice, InvoiceDto>()
                .ForMember(dto => dto.SalesDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.SalesDate))); 
            CreateMap<InvoiceDto, Invoice>()
                .ForMember(dto => dto.SalesDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.SalesDate)));

            CreateMap<Purchasemst, PurchasemstDto>()
                .ForMember(dto => dto.PurchaseDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.PurchaseDate)));
            CreateMap<PurchasemstDto, Purchasemst>()
                .ForMember(dto => dto.PurchaseDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.PurchaseDate)));
        }
    }
}
