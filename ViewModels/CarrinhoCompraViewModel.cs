using LanchesMac.Models;

namespace LanchesMac.ViewModels;

//view model é aquilo que eu quero exibir na view.
//vai ser usado no controlador.
public class CarrinhoCompraViewModel
{
    public CarrinhoCompra CarrinhoCompra { get; set; }
    public decimal CarrinhoCompraTotal { get; set; }

}
