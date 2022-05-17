using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt
{
    public class ReceiptPrinterHTML : IPrinter
    {
        private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-GB");

        public string PrintReceipt(Receipt receipt)
        {
            var result = new StringBuilder();
            result.Append("<html><body>");

            PrintReceiptItem(receipt, result);
            PrintDiscount(receipt, result);
            PrintTotal(receipt, result);

            result.Append("</body><html>");

            return result.ToString();

        }

        private void PrintDiscount(Receipt receipt, StringBuilder result)
        {
            result.Append(@"<h3>Discount</h3>");

            result.Append(@"<table>
                    <tr>
                     <th>Item</th>
                     <th>Description</th>
                     <th>Discount</th>
                    </tr>
            ");

            foreach (var item in receipt.GetDiscounts())
            {
                result.Append(@$"
                    <tr>
                     <td>{item.Product.Name}</td>
                     <td>{item.Description}</td>
                     <td>{PrintPrice(item.DiscountAmount)}</td>
                    </tr>
                ");
            }

            result.Append(@"</table>");
        }

        private void PrintReceiptItem(Receipt receipt, StringBuilder result)
        {
            result.Append(@"<h3>Itens</h3>");

            result.Append(@"<table>
                    <tr>
                     <th>Item</th>
                     <th>Quantity</th>
                     <th>Price</th>
                     <th>Total Price</th>
                    </tr>
            ");

            foreach (var item in receipt.GetItems())
            {
                result.Append(@$"
                    <tr>
                     <td>{item.Product.Name}</td>
                     <td>{PrintQuantity(item)}</td>
                     <td>{PrintPrice(item.Price)}</td>
                     <td>{PrintPrice(item.TotalPrice)}</td>
                    </tr>
                ");
            }

            result.Append(@"</table>");
        }

        private void PrintTotal(Receipt receipt, StringBuilder result)
        {
            string total = $"<h2>Total: {PrintPrice(receipt.GetTotalPrice())}<h2>";
            result.Append(total);
        }

        private string PrintPrice(double price)
        {
            return price.ToString("N2", Culture);
        }

        private static string PrintQuantity(ReceiptItem item)
        {
            return ProductUnit.Each == item.Product.Unit
                ? ((int)item.Quantity).ToString()
                : item.Quantity.ToString("N3", Culture);
        }
    }
}
