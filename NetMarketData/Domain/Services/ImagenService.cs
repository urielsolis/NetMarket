using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using NetMarketData.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Services
{
    public class ImagenService
    {
        private readonly ImagenRepositorio imagenrepositorio;

        public ImagenService()
        {
            this.imagenrepositorio = new ImagenRepositorio();
        }

        public long Guardarimagen(ImagenDTO i)
        {
            if (i.idImagen == 0)
                i.idImagen = imagenrepositorio.guardarimagen(i);
            else
                imagenrepositorio.ModificarImagen(i);
            return i.idImagen;
        }

        public void Eliminarimagen(ImagenDTO i)
        {
            imagenrepositorio.Eliminarimagen(i);
        }

        public string Obtenerimagen(ImagenDTO i)
        {
            return imagenrepositorio.obtenerimagen(i);
        }

        public List<Imagen> Obtenerimagenes(ImagenDTO i)
        {
            return imagenrepositorio.obtenerimagenes(i);
        }
    }
}
