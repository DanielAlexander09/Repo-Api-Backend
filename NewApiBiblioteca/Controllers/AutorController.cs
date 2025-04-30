using Microsoft.AspNetCore.Mvc;
using ApiBook.Core.Application.Interfaces;
using ApiBook.Core.Application.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApiBook.Core.Application.Services;

namespace ApiBook.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorServices;

        public AutorController(IAutorInterface autorServices)
        {
            _autorServices = autorServices;
        }

        // Acción para obtener todos los autores
        [HttpGet]
        public async Task<ActionResult<List<AutorViewModels>>> GetAutores()
        {
            try
            {
                var autores = await _autorServices.GetAuthorsAsync();
                return Ok(autores); // Retorna los autores con un código de estado 200
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener los autores: {ex.Message}");
            }
        }

        // Acción para agregar un nuevo autor
        [HttpPost]
        public async Task<ActionResult> CrearAutor([FromBody] AutorViewModels autorView)
        {
            try
            {
                await _autorServices.CreateAuthorAsync(autorView);
                return CreatedAtAction(nameof(GetAutores), new { id = autorView.id }, autorView); // Retorna el autor creado
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al crear el autor: {ex.Message}");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorViewModels>> GetAutorById(int id)
        {
            try
            {
                var autor = await _autorServices.GetAuthorByIdAsync(id);
                if (autor == null)
                {
                    return NotFound($"Autor con ID {id} no encontrado");
                }
                return Ok(autor); // Retorna el autor encontrado
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al obtener el autor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarAutor(int id, [FromBody] AutorViewModels autorView)
        {
            try
            {
                // Se asume que ActualizarAutor retorna un valor booleano o maneja el error internamente
                var autorExistente = await _autorServices.GetAuthorByIdAsync(id);
                if (autorExistente == null)
                {
                    return NotFound($"Autor con ID {id} no encontrado");
                }

                await _autorServices.UpdateAuthorAsync(id, autorView);
                return NoContent(); // Retorna 204 No Content indicando que la actualización fue exitosa
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el autor: {ex.Message}");
            }
        }

        // Acción para eliminar un autor
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarAutor(int id)
        {
            try
            {
                var autorExistente = await _autorServices.GetAuthorByIdAsync(id);
                if (autorExistente == null)
                {
                    return NotFound($"Autor con ID {id} no encontrado");
                }

                await _autorServices.DeleteAuthorAsync(id);
                return NoContent(); // Retorna 204 No Content indicando que la eliminación fue exitosa
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar el autor: {ex.Message}");
            }
        }

    }
}
