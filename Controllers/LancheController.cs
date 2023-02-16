using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers;

public class LancheController : Controller
{
    private readonly ILancheRepository _lancheRepository;
    private readonly ICategoriaRepository _categoriaRepository;

    //injetando a dependencia no construtor.
    public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
    {
        _lancheRepository = lancheRepository;
        _categoriaRepository = categoriaRepository;
    }

    public IActionResult List(string categoria)
    {
        string _categoria = categoria;
        IEnumerable<Lanche> lanches;
        string categoriaAtual = string.Empty;

        //se não informar a categoria irá exibir todos os lanches.
        if(string.IsNullOrEmpty(categoria))
        {
            lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
            categoria = "Todos os lancehs";
        }
        else
        {
            if(string.Equals("Normal",_categoria, StringComparison.OrdinalIgnoreCase))
            {
                lanches = _lancheRepository.Lanches.Where(
                    l => l.Categoria.CategoriaNome.Equals("Normal")).OrderBy(l => l.Nome);
            }
            else
            {
                lanches = _lancheRepository.Lanches.Where(
                   l => l.Categoria.CategoriaNome.Equals("Natural")).OrderBy(l => l.Nome);
            }
            categoriaAtual = _categoria;
        }

        //exibindo na view
        var lanchesListViewModel = new LancheListViewModel
        {
            Lanches = lanches,
            CategoriaAtual=categoriaAtual,
        };
       
        return View( lanchesListViewModel );

    }
    
}
