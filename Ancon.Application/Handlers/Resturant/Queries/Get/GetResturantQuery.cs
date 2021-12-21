﻿using Ancon.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.Resturant.Queries.Get
{
    public class GetResturantQuery : IRequest<List<ResturantQueryModel>> { }
}
