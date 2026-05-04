using FluentValidation;
using TeamTasker.API.DTOs;

namespace TeamTasker.API.Validators
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskDto>
    {
        public UpdateTaskDtoValidator()
        {
            RuleFor(task => task.Title)
                .NotEmpty().WithMessage("O título da tarefa é obrigatório para atualização.")
                .MinimumLength(3).WithMessage("O título deve ter no mínimo 3 caracteres.")
                .MaximumLength(100).WithMessage("O título não pode exceder 100 caracteres.");

            RuleFor(task => task.Description)
                .MaximumLength(500).WithMessage("A descrição não pode ter mais de 500 caracteres.");
                
            
        }
    }
}