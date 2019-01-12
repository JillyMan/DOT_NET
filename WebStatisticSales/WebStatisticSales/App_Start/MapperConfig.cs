using AutoMapper;
using DAL.Models;
using WebStatisticSales.Models;

namespace WebStatisticSales
{
	public class MapperConfig
	{
		public static void RegisterMap()
		{
			Mapper.Initialize(cfg => {
				cfg.CreateMap<Client, ClientIndexView>();
				cfg.CreateMap<Client, ClientCreateView>().ReverseMap();
				cfg.CreateMap<Client, ClientEditView>();
				cfg.CreateMap<Client, ClientEditView>().ReverseMap();

				cfg.CreateMap<Seller, SellerIndexView>();
				cfg.CreateMap<Seller, SellerCreateView>().ReverseMap();
				cfg.CreateMap<Seller, SellerEditView>();
				cfg.CreateMap<Seller, SellerEditView>().ReverseMap();

				cfg.CreateMap<Product, ProductIndexView>();
				cfg.CreateMap<Product, ProductCreateView>().ReverseMap();
				cfg.CreateMap<Product, ProductEditView>();
				cfg.CreateMap<Product, ProductEditView>().ReverseMap();

				cfg.CreateMap<Sale, SaleView>()
					.ForMember(x => x.Seller, opt => opt.MapFrom(c => c.Seller.Name))
					.ForMember(x => x.Client, opt => opt.MapFrom(c => c.Client.Name))
					.ForMember(x => x.Product, opt => opt.MapFrom(c => c.Product.Name));

				cfg.CreateMap<SaleCreateView, Sale>();
				cfg.CreateMap<SaleEditView, Sale>();
			});
		}
	}
}