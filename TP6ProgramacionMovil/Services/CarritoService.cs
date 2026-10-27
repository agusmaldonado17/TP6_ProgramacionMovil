using System;
using System.Collections.Generic;
using System.Text;

using TP6ProgramacionMovil.Models;

namespace TP6ProgramacionMovil.Services
{
    public class CarritoService
    {
        public List<ItemCarrito> Items { get; private set; } = new();

        public event Action? OnCarritoChanged;

        public int CantidadTotal =>
            Items.Sum(i => i.Cantidad);

        public decimal Total =>
            Items.Sum(i => i.Subtotal);


        public bool AgregarProducto(ProductoResponse producto)
        {
            if (producto.StockActual <= 0)
                return false;

            var item = Items
                .FirstOrDefault(i =>
                    i.Producto.Id == producto.Id);

            if (item == null)
            {
                Items.Add(new ItemCarrito
                {
                    Producto = producto,
                    Cantidad = 1
                });
            }
            else
            {
                if (item.Cantidad >= producto.StockActual)
                    return false;

                item.Cantidad++;
            }

            OnCarritoChanged?.Invoke();

            return true;
        }


        public bool AumentarCantidad(int productoId)
        {
            var item = Items
                .FirstOrDefault(i =>
                    i.Producto.Id == productoId);

            if (item == null)
                return false;

            if (item.Cantidad >= item.Producto.StockActual)
                return false;

            item.Cantidad++;

            OnCarritoChanged?.Invoke();

            return true;
        }


        public void DisminuirCantidad(int productoId)
        {
            var item = Items
                .FirstOrDefault(i =>
                    i.Producto.Id == productoId);

            if (item == null)
                return;

            item.Cantidad--;

            if (item.Cantidad <= 0)
            {
                Items.Remove(item);
            }

            OnCarritoChanged?.Invoke();
        }


        public void EliminarProducto(int productoId)
        {
            var item = Items
                .FirstOrDefault(i =>
                    i.Producto.Id == productoId);

            if (item == null)
                return;

            Items.Remove(item);

            OnCarritoChanged?.Invoke();
        }


        public void Vaciar()
        {
            Items.Clear();

            OnCarritoChanged?.Invoke();
        }
    }
}