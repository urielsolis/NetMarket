using Data.Infrastructure.Data.Repositories;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Infrastructure.Data.Repositories
{
    public class ImagenRepositorio : EFRepositorio<Imagen>
    {
        public long guardarimagen(ImagenDTO i)
        {
            Imagen im = new Imagen()
            {
                rutaImagen = i.ruta,
                idCategoria=i.idcategoria,
                idProducto=i.idProducto, 
                idProductoEmpresa =i.idProductoEmpresa, 
                idProductoSucursal=i.idProductoSucursal, 
                idEmpresa =i.idEmpresa,
                idSucursal =i.idSucursal,
                idOferta=i.idOferta,
                Principal=i.principal,
                eliminado = false
            };
            Add(im);
            SaveChanges();
            return im.idImagen;
        }

        public void ModificarImagen(ImagenDTO i)
        {
            Imagen im = this.Get(i.idImagen);
            im.rutaImagen = i.ruta;
            im.Principal = i.principal;
            Update(im);
            SaveChanges();
        }

        public void Eliminarimagen(ImagenDTO i)
        {
            Imagen im = Get(i.idImagen);
            im.eliminado = true;
            SaveChanges();
        }

        public string obtenerimagen(ImagenDTO i)
        {
            try
            {
                string ruta = "";
                if (!string.IsNullOrEmpty(i.idProducto.ToString())&& i.idProducto.ToString()!="0")
                {
                    ruta= BuildQuery().Where(x => x.eliminado == false && x.Producto.idProducto == i.idProducto).First().rutaImagen;
                }
                else
                {
                    if (!string.IsNullOrEmpty(i.idProductoEmpresa.ToString()) && i.idProductoEmpresa.ToString() != "0")
                    {
                        ruta = BuildQuery().Where(x => x.eliminado == false && x.ProductoEmpresa.idProductoEmpresa == i.idProductoEmpresa).First().rutaImagen;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(i.idProductoSucursal.ToString()) && i.idProductoSucursal.ToString() != "0")
                        {
                            ruta = BuildQuery().Where(x => x.eliminado == false && x.ProductoSucursal.idProductoSucursal == i.idProductoSucursal).First().rutaImagen;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(i.idEmpresa.ToString()) && i.idEmpresa.ToString() != "0")
                            {
                                ruta = BuildQuery().Where(x => x.eliminado == false && x.idEmpresa == i.idEmpresa).First().rutaImagen;
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(i.idSucursal.ToString()) && i.idSucursal.ToString() != "0")
                                {
                                    ruta = BuildQuery().Where(x => x.eliminado == false && x.idSucursal == i.idSucursal).First().rutaImagen;
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(i.idpersona.ToString()) && i.idpersona.ToString() != "0")
                                    {
                                        ruta = BuildQuery().Where(x => x.eliminado == false && x.idPersona == i.idpersona).First().rutaImagen;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(i.idcategoria.ToString()) && i.idcategoria.ToString() != "0")
                                        {
                                            ruta = BuildQuery().Where(x => x.eliminado == false && x.idCategoria == i.idcategoria).First().rutaImagen;
                                        }
                                        else
                                        {
                                            ruta = BuildQuery().Where(x => x.eliminado == false && x.idOferta == i.idOferta).First().rutaImagen;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return ruta;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public List<Imagen> obtenerimagenes(ImagenDTO i)
        {
            if (!string.IsNullOrEmpty(i.idProducto.ToString()))
            {
                return BuildQuery().Where(x => x.eliminado == false && x.Producto.idProducto == i.idProducto).ToList();
            }
            else
            {
                if (!string.IsNullOrEmpty(i.idProductoEmpresa.ToString()))
                {
                    return BuildQuery().Where(x => x.eliminado == false && x.ProductoEmpresa.idProductoEmpresa == i.idProductoEmpresa).ToList();
                }
                else
                {
                    if (!string.IsNullOrEmpty(i.idProductoSucursal.ToString()))
                    {
                        return BuildQuery().Where(x => x.eliminado == false && x.ProductoSucursal.idProductoSucursal == i.idProductoSucursal).ToList();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(i.idEmpresa.ToString()))
                        {
                            return BuildQuery().Where(x => x.eliminado == false && x.Empresa.idEmpresa == i.idEmpresa).ToList();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(i.idSucursal.ToString()))
                            {
                                return BuildQuery().Where(x => x.eliminado == false && x.Sucursal.idSucursal == i.idSucursal).ToList();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(i.idpersona.ToString()))
                                {
                                    return BuildQuery().Where(x => x.eliminado == false && x.Persona.idPersona == i.idpersona).ToList();
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(i.idcategoria.ToString()))
                                    {
                                        return BuildQuery().Where(x => x.eliminado == false && x.CategoriaProducto.idCategoria == i.idcategoria).ToList();
                                    }
                                    else
                                    {
                                        return BuildQuery().Where(x => x.eliminado == false && x.oferta.idOferta == i.idOferta).ToList();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

    }
}
