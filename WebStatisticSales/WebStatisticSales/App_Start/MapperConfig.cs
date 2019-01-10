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

				cfg.CreateMap<Client, ClientIndexView>().ReverseMap();
				cfg.CreateMap<Client, ClientEditView>().ReverseMap();
				cfg.CreateMap<Client, ClientCreateView>().ReverseMap();

				cfg.CreateMap<Product, ProductIndexView>().ReverseMap();
				cfg.CreateMap<Product, ProductCreateView>().ReverseMap();
				cfg.CreateMap<Product, ProductEditView>().ReverseMap();


				cfg.CreateMap<Sale, SaleView>()
					.ForMember("Id", opt => opt.MapFrom(c => c.Id))
					.ForMember("Seller", opt => opt.MapFrom(c => c.Seller.Name))
					.ForMember("Client", opt => opt.MapFrom(c => c.Client.Name))
					.ForMember("Cost", opt => opt.MapFrom(c => c.Summa))
					.ForMember("Date", opt => opt.MapFrom(c => c.Date));

				//cfg.CreateMap<Sale, SaleditView>().ReverseMap();
				//cfg.CreateMap<Sale, SaleCreateView>().ReverseMap();
			});
		}
	}
}