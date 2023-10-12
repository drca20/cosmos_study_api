using AutoMapper;
using Cosmos_Study.Application.Features.Products.Commands.CreateProduct;
using Cosmos_Study.Application.Features.Products.Queries.GetAllProducts;
using Cosmos_Study.Application.Features.Study.Commands;
using Cosmos_Study.Application.Features.Study.Queries.GetAllStudy;
using Cosmos_Study.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos_Study.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            CreateMap<GetAllStudyWithPagination, GetAllStudyParameter>();
            CreateMap<CreateStudyCommand, Study>();
            CreateMap<CreateStudyContactsCommand, StudyContacts>();
            CreateMap<Study, GetAllStudyViewModel>().ReverseMap();
        }
    }
}
