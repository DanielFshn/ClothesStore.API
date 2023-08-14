using AutoMapper.QueryableExtensions;
using ClothesStrore.Application.Context;
using ClothesStrore.Application.User.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClothesStrore.Application.Categoty.GetCategories
{
    public class GetAllCategoriesRequestHandler : IRequestHandler<GetAllCategoriesRequest, List<GetAllCategoriesResponse>>
    {
        public IMapper _mapper { get; }
        public IMyDbContext _context { get; }

        public GetAllCategoriesRequestHandler(IMapper mapper, IMyDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }



        public async Task<List<GetAllCategoriesResponse>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories.ToListAsync(cancellationToken);
            var response = _mapper.Map<List<GetAllCategoriesResponse>>(categories);
            return response;
        }
    }
}
