using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStatisticSales.Models;

namespace WebStatisticSales
{
	public class MapperConfig
	{
		public static void RegisterMap()
		{
			Mapper.Initialize(cfg => {
				cfg.CreateMap<Client, ClientIndexView>();
				cfg.CreateMap<Client, ClientCreateView>();
				cfg.CreateMap<Client, ClientEditView>();

			//	cfg.CreateMap<Client, ClientIndexView>().ReverseMap();
				cfg.CreateMap<Client, ClientEditView>().ReverseMap();
				cfg.CreateMap<Client, ClientCreateView>().ReverseMap();

			//	cfg.CreateMap<Product, ProductIndexView>().ReverseMap();
				cfg.CreateMap<Product, ProductCreateView>().ReverseMap();
				cfg.CreateMap<Product, ProductEditView>().ReverseMap();

				cfg.CreateMap<Sale, SaleView>()
					.ForMember(x => x.Id, opt => opt.MapFrom(c => c.Id))
					.ForMember(x => x.Seller, opt => opt.MapFrom(c => c.Seller.Name))
					.ForMember(x => x.Client, opt => opt.MapFrom(c => c.Client.Name))
					.ForMember(x => x.Product, opt => opt.MapFrom(c => c.Product.Name))
					.ForMember(x => x.Cost, opt => opt.MapFrom(c => c.Summa))
					.ForMember(x => x.Date, opt => opt.MapFrom(c => c.Date));

				cfg.CreateMap<Sale, SaleEditView>().ReverseMap()
					.ForMember(x => x.Summa, opt => opt.MapFrom(c => c.Cost));

				cfg.CreateMap<Sale, SaleEditView> ()
					.ForMember(x => x.Cost, opt => opt.MapFrom(c => c.Summa));

				cfg.CreateMap<SaleCreateView, Sale>()
					.ForMember(x => x.Summa, opt => opt.MapFrom(c => c.Cost));

				//cfg.CreateMap<Sale, Sa{editView>().ReverseMap();
				//cfg.CreateMap<Sale, SaleCreateView>().ReverseMap();
			});
		}
	}
}