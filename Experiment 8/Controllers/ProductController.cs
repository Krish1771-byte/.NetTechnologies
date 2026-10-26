
using Practical_8.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Practical_8.Controllers
{
    public class ProductController : Controller
    {
        // Database connection
        private readonly string cs =
            @"Data Source=(localdb)\ProjectModels;Initial Catalog=InventroyDB;Integrated Security=True;Connect Timeout=30";

        // GET: Product/Index
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Products ORDER BY ProductId";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = Convert.ToInt32(dr["ProductId"]),
                            ProductName = dr["ProductName"].ToString(),
                            Quantity = Convert.ToInt32(dr["Quantity"]),
                            Price = Convert.ToDecimal(dr["Price"])
                        });
                    }
                }
            }

            return View(products);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View(new Product());
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                // ProductId is generated automatically by SQL Server
                string query = @"
                    INSERT INTO Products
                    (ProductName, Quantity, Price)
                    VALUES
                    (@ProductName, @Quantity, @Price)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@ProductName", p.ProductName);

                cmd.Parameters.AddWithValue(
                    "@Quantity", p.Quantity);

                cmd.Parameters.AddWithValue(
                    "@Price", p.Price);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // GET: Product/Edit/1
        public ActionResult Edit(int id)
        {
            Product p = null;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query =
                    "SELECT * FROM Products WHERE ProductId = @ProductId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", id);

                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        p = new Product
                        {
                            ProductId = Convert.ToInt32(dr["ProductId"]),
                            ProductName = dr["ProductName"].ToString(),
                            Quantity = Convert.ToInt32(dr["Quantity"]),
                            Price = Convert.ToDecimal(dr["Price"])
                        };
                    }
                }
            }

            if (p == null)
            {
                return HttpNotFound();
            }

            return View(p);
        }

        // POST: Product/Edit
        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
                    UPDATE Products
                    SET ProductName = @ProductName,
                        Quantity = @Quantity,
                        Price = @Price
                    WHERE ProductId = @ProductId";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@ProductId", p.ProductId);

                cmd.Parameters.AddWithValue(
                    "@ProductName", p.ProductName);

                cmd.Parameters.AddWithValue(
                    "@Quantity", p.Quantity);

                cmd.Parameters.AddWithValue(
                    "@Price", p.Price);

                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    return HttpNotFound();
                }
            }

            return RedirectToAction("Index");
        }

        // POST: Product/Delete/1
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query =
                    "DELETE FROM Products WHERE ProductId = @ProductId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ProductId", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }
    }
}
