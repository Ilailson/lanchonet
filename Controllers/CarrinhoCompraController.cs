using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class CarrinhoCompraController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    private readonly CarrinhoCompra _carrinhoCompra;

    public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
    {
        _lancheRepository = lancheRepository;
        _carrinhoCompra = carrinhoCompra;

    }
    public IActionResult Index()
    {
        //criar view model

        var itens = _carrinhoCompra.GetCarrinhoCompraItens();

        //atribuir os itens do carrinho.
        _carrinhoCompra.CarrinhoCompraItems= itens;

        var carrinhoComprasViewModel = new CarrinhoCompraViewModel
        {
            CarrinhoCompra = _carrinhoCompra,
            CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
        };
        return View(carrinhoComprasViewModel);
    }

    public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId)
    {
        var lancheSelecionado = _lancheRepository.Lanches
                                .FirstOrDefault(p => p.LancheId == lancheId);

        if (lancheSelecionado != null)
        {
            _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
        }
        return RedirectToAction("Index");
    }

    public IActionResult RemoverItemDoCarrinhoCompra(int lancheId)
    {
        var lancheSelecionado = _lancheRepository.Lanches
                                .FirstOrDefault(p => p.LancheId == lancheId);

        if (lancheSelecionado != null)
        {
            _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);
        }
        return RedirectToAction("Index");
    }
}
