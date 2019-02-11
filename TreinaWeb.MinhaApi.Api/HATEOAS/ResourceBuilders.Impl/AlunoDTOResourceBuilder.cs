using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;
using TreinaWeb.MinhaApi.Api.DTOs;
using TreinaWeb.MinhaApi.Api.HATEOAS.ResourceBuilders.Interfaces;

namespace TreinaWeb.MinhaApi.Api.HATEOAS.ResourceBuilders.Impl
{
    public class AlunoDTOResourceBuilder : IResourceBuilders
    {
        public void BuildResource(object resource, HttpRequestMessage request)
        {
            AlunoDTO dto = resource as AlunoDTO;

            if (dto == null)
                throw new ArgumentException($"Era esperado um 'AlunoDTO', mas foi enviado um {resource.GetType().Name}");

            UrlHelper urlHelper = new UrlHelper(request);
            string AlunoDTORoute = urlHelper.Link("DefaultApi", new { controller = "Alunos", id = dto.Id });
            dto.Links.Add(new RestLink
            {
                Rel = "getById",
                Href = AlunoDTORoute
            });
            dto.Links.Add(new RestLink
            {
                Rel = "put",
                Href = AlunoDTORoute
            });
            dto.Links.Add(new RestLink
            {
                Rel = "delete",
                Href = AlunoDTORoute
            });
        }
    }
}