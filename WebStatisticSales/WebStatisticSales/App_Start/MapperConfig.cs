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
					.ForMember(x => x.Seller, opt => opt.MapFrom(c => c.Seller.Name))
					.ForMember(x => x.Client, opt => opt.MapFrom(c => c.Client.Name))
					.ForMember(x => x.Product, opt => opt.MapFrom(c => c.Product.Name));

				cfg.CreateMap<SaleCreateView, Sale>();
				cfg.CreateMap<SaleEditView, Sale>();

				/* 
					Id = sale.Id,
					Cost = sale.Cost,
					Date = sale.Date,
					ClientId = sale.ClientId.Value,
					SellerId = sale.SellerId.Value,
					ProductId = sale.ProductId.Value,
				*/
				//cfg.CreateMap<Sale, Sa{editView>().ReverseMap();
				//cfg.CreateMap<Sale, SaleCreateView>().ReverseMap();
			});
		}
	}
}