using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_WPF.Model;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public OP Op { get; set; }
    public int Item { get; set; }
}
