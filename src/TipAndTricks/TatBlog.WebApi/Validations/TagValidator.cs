﻿using FluentValidation;
using TatBlog.WebApi.Models;

namespace TatBlog.WebApi.Validations
{
    public class TagValidator : AbstractValidator<TagEditModel>
    {
        public TagValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Tên từ khoá không được để trống")
                .MaximumLength(100)
                .WithMessage("Tên từ khoá tối đa 100 kí tự");

            RuleFor(a => a.UrlSlug)
                .NotEmpty()
                .WithMessage("UrlSlug từ khoá không được để trống")
                .MaximumLength(1000)
                .WithMessage("UrlSlug từ khoá tối đa 1000 kí tự");

            RuleFor(a => a.Description)
                .NotEmpty()
                .WithMessage("Description từ khoá không được để trống")
                .MaximumLength(100)
                .WithMessage("Description từ khoá tối đa 100 kí tự");

        }
    }
}