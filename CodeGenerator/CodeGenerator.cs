using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeGenerator
{
    public class CodeGenerator
    {
        private readonly string _basePath;

        public CodeGenerator(string basePath)
        {
            _basePath = basePath;
        }

        public void GenerateCode(Type modelType)
        {
            GenerateViewModel(modelType);
            GenerateService(modelType);
            GenerateController(modelType);
            GenerateView(modelType);
            GenerateAutoMapperProfile(modelType);
        }

        private void GenerateViewModel(Type modelType)
        {
            string viewModelCode = $@"
using System;
using System.ComponentModel.DataAnnotations;

namespace RZRV.APP.ViewModels
{{
    public class {modelType.Name}ViewModel
    {{
{string.Join("\n", modelType.GetProperties().Select(p => $"        [Display(Name = \"{AddSpacesToSentence(p.Name)}\")]\n        public {GetViewModelPropertyType(p.PropertyType)} {p.Name} {{ get; set; }}"))}
    }}
}}";

            string filePath = Path.Combine(_basePath, "ViewModels", $"{modelType.Name}ViewModel.cs");
            File.WriteAllText(filePath, viewModelCode);
        }

        private void GenerateService(Type modelType)
        {
            string serviceInterfaceCode = $@"
using System.Collections.Generic;
using System.Threading.Tasks;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Services.Interfaces
{{
    public interface I{modelType.Name}Service
    {{
        Task<IEnumerable<{modelType.Name}ViewModel>> GetAllAsync();
        Task<{modelType.Name}ViewModel> GetByIdAsync(int id);
        Task Create{modelType.Name}Async({modelType.Name}ViewModel viewModel);
        Task Update{modelType.Name}Async({modelType.Name}ViewModel viewModel);
        Task Delete{modelType.Name}Async(int id);
    }}
}}";

            string serviceImplementationCode = $@"
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RZRV.APP.Models;
using RZRV.APP.Services.Interfaces;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Services
{{
    public class {modelType.Name}Service : I{modelType.Name}Service
    {{
        private readonly IMapper _mapper;
        // Add your repository or data access layer here

        public {modelType.Name}Service(IMapper mapper)
        {{
            _mapper = mapper;
            // Initialize your repository or data access layer
        }}

        public async Task<IEnumerable<{modelType.Name}ViewModel>> GetAllAsync()
        {{
            // Implement the logic to get all entities
            throw new NotImplementedException();
        }}

        public async Task<{modelType.Name}ViewModel> GetByIdAsync(int id)
        {{
            // Implement the logic to get an entity by id
            throw new NotImplementedException();
        }}

        public async Task Create{modelType.Name}Async({modelType.Name}ViewModel viewModel)
        {{
            // Implement the logic to create a new entity
            throw new NotImplementedException();
        }}

        public async Task Update{modelType.Name}Async({modelType.Name}ViewModel viewModel)
        {{
            // Implement the logic to update an existing entity
            throw new NotImplementedException();
        }}

        public async Task Delete{modelType.Name}Async(int id)
        {{
            // Implement the logic to delete an entity
            throw new NotImplementedException();
        }}
    }}
}}";

            string interfaceFilePath = Path.Combine(_basePath, "Services", "Interfaces", $"I{modelType.Name}Service.cs");
            string implementationFilePath = Path.Combine(_basePath, "Services", $"{modelType.Name}Service.cs");

            File.WriteAllText(interfaceFilePath, serviceInterfaceCode);
            File.WriteAllText(implementationFilePath, serviceImplementationCode);
        }

        private void GenerateController(Type modelType)
        {
            string controllerCode = $@"
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RZRV.APP.Services.Interfaces;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Controllers
{{
    public class {modelType.Name}Controller : Controller
    {{
        private readonly I{modelType.Name}Service _{modelType.Name.ToLower()}Service;

        public {modelType.Name}Controller(I{modelType.Name}Service {modelType.Name.ToLower()}Service)
        {{
            _{modelType.Name.ToLower()}Service = {modelType.Name.ToLower()}Service;
        }}

        public async Task<IActionResult> Index()
        {{
            var viewModels = await _{modelType.Name.ToLower()}Service.GetAllAsync();
            return View(viewModels);
        }}

        public async Task<IActionResult> Details(int id)
        {{
            var viewModel = await _{modelType.Name.ToLower()}Service.GetByIdAsync(id);
            if (viewModel == null)
            {{
                return NotFound();
            }}
            return View(viewModel);
        }}

        public IActionResult Create()
        {{
            return View();
        }}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create({modelType.Name}ViewModel viewModel)
        {{
            if (ModelState.IsValid)
            {{
                await _{modelType.Name.ToLower()}Service.Create{modelType.Name}Async(viewModel);
                return RedirectToAction(nameof(Index));
            }}
            return View(viewModel);
        }}

        public async Task<IActionResult> Edit(int id)
        {{
            var viewModel = await _{modelType.Name.ToLower()}Service.GetByIdAsync(id);
            if (viewModel == null)
            {{
                return NotFound();
            }}
            return View(viewModel);
        }}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, {modelType.Name}ViewModel viewModel)
        {{
            if (id != viewModel.Id)
            {{
                return NotFound();
            }}

            if (ModelState.IsValid)
            {{
                await _{modelType.Name.ToLower()}Service.Update{modelType.Name}Async(viewModel);
                return RedirectToAction(nameof(Index));
            }}
            return View(viewModel);
        }}

        public async Task<IActionResult> Delete(int id)
        {{
            var viewModel = await _{modelType.Name.ToLower()}Service.GetByIdAsync(id);
            if (viewModel == null)
            {{
                return NotFound();
            }}
            return View(viewModel);
        }}

        [HttpPost, ActionName(""Delete"")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {{
            await _{modelType.Name.ToLower()}Service.Delete{modelType.Name}Async(id);
            return RedirectToAction(nameof(Index));
        }}
    }}
}}";

            string filePath = Path.Combine(_basePath, "Controllers", $"{modelType.Name}Controller.cs");
            File.WriteAllText(filePath, controllerCode);
        }

        private void GenerateView(Type modelType)
        {
            GenerateIndexView(modelType);
            GenerateDetailsView(modelType);
            GenerateCreateView(modelType);
            GenerateEditView(modelType);
            GenerateDeleteView(modelType);
        }

        private void GenerateIndexView(Type modelType)
        {
            string viewCode = $@"
@model IEnumerable<RZRV.APP.ViewModels.{modelType.Name}ViewModel>

@{{
    ViewData[""Title""] = ""{modelType.Name} Index"";
}}

<h1>{modelType.Name} Index</h1>

<p>
    <a asp-action=""Create"">Create New</a>
</p>
<table class=""table"">
    <thead>
        <tr>
{string.Join("\n", modelType.GetProperties().Select(p => $"            <th>@Html.DisplayNameFor(model => model.{p.Name})</th>"))}
            <th></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model) {{
        <tr>
{string.Join("\n", modelType.GetProperties().Select(p => $"            <td>@Html.DisplayFor(modelItem => item.{p.Name})</td>"))}
            <td>
                <a asp-action=""Edit"" asp-route-id=""@item.Id"">Edit</a> |
                <a asp-action=""Details"" asp-route-id=""@item.Id"">Details</a> |
                <a asp-action=""Delete"" asp-route-id=""@item.Id"">Delete</a>
            </td>
        </tr>
}}
    </tbody>
</table>
";

            string filePath = Path.Combine(_basePath, "Views", modelType.Name, "Index.cshtml");
            EnsureDirectoryExists(filePath);
            File.WriteAllText(filePath, viewCode);
        }

        private void GenerateDetailsView(Type modelType)
        {
            string viewCode = $@"
@model RZRV.APP.ViewModels.{modelType.Name}ViewModel

@{{
    ViewData[""Title""] = ""{modelType.Name} Details"";
}}

<h1>{modelType.Name} Details</h1>

<div>
    <h4>{modelType.Name}</h4>
    <hr />
    <dl class=""row"">
{string.Join("\n", modelType.GetProperties().Select(p => $@"        <dt class=""col-sm-2"">
            @Html.DisplayNameFor(model => model.{p.Name})
        </dt>
        <dd class=""col-sm-10"">
            @Html.DisplayFor(model => model.{p.Name})
        </dd>"))}
    </dl>
</div>
<div>
    <a asp-action=""Edit"" asp-route-id=""@Model.Id"">Edit</a> |
    <a asp-action=""Index"">Back to List</a>
</div>
";

            string filePath = Path.Combine(_basePath, "Views", modelType.Name, "Details.cshtml");
            EnsureDirectoryExists(filePath);
            File.WriteAllText(filePath, viewCode);
        }

        private void GenerateCreateView(Type modelType)
        {
            string viewCode = $@"
@model RZRV.APP.ViewModels.{modelType.Name}ViewModel

@{{
    ViewData[""Title""] = ""Create {modelType.Name}"";
}}

<h1>Create {modelType.Name}</h1>

<h4>{modelType.Name}</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
{string.Join("\n", modelType.GetProperties().Where(p => p.Name != "Id").Select(p => $@"            <div class=""form-group"">
                <label asp-for=""{p.Name}"" class=""control-label""></label>
                <input asp-for=""{p.Name}"" class=""form-control"" />
                <span asp-validation-for=""{p.Name}"" class=""text-danger""></span>
            </div>"))}
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
";

            string filePath = Path.Combine(_basePath, "Views", modelType.Name, "Create.cshtml");
            EnsureDirectoryExists(filePath);
            File.WriteAllText(filePath, viewCode);
        }

        private void GenerateEditView(Type modelType)
        {
            string viewCode = $@"
@model RZRV.APP.ViewModels.{modelType.Name}ViewModel

@{{
    ViewData[""Title""] = ""Edit {modelType.Name}"";
}}

<h1>Edit {modelType.Name}</h1>

<h4>{modelType.Name}</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""Id"" />
{string.Join("\n", modelType.GetProperties().Where(p => p.Name != "Id").Select(p => $@"            <div class=""form-group"">
                <label asp-for=""{p.Name}"" class=""control-label""></label>
                <input asp-for=""{p.Name}"" class=""form-control"" />
                <span asp-validation-for=""{p.Name}"" class=""text-danger""></span>
            </div>"))}
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
";

            string filePath = Path.Combine(_basePath, "Views", modelType.Name, "Edit.cshtml");
            EnsureDirectoryExists(filePath);
            File.WriteAllText(filePath, viewCode);
        }

        private void GenerateDeleteView(Type modelType)
        {
            string viewCode = $@"
@model RZRV.APP.ViewModels.{modelType.Name}ViewModel

@{{
    ViewData[""Title""] = ""Delete {modelType.Name}"";
}}

<h1>Delete {modelType.Name}</h1>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>{modelType.Name}</h4>
    <hr />
    <dl class=""row"">
{string.Join("\n", modelType.GetProperties().Select(p => $@"        <dt class=""col-sm-2"">
            @Html.DisplayNameFor(model => model.{p.Name})
        </dt>
        <dd class=""col-sm-10"">
            @Html.DisplayFor(model => model.{p.Name})
        </dd>"))}
    </dl>
    
    <form asp-action=""Delete"">
        <input type=""hidden"" asp-for=""Id"" />
        <input type=""submit"" value=""Delete"" class=""btn btn-danger"" /> |
        <a asp-action=""Index"">Back to List</a>
    </form>
</div>
";

            string filePath = Path.Combine(_basePath, "Views", modelType.Name, "Delete.cshtml");
            EnsureDirectoryExists(filePath);
            File.WriteAllText(filePath, viewCode);
        }

        private void GenerateAutoMapperProfile(Type modelType)
        {
            string profileCode = $@"
using AutoMapper;
using RZRV.APP.Models;
using RZRV.APP.ViewModels;

namespace RZRV.APP.Mappings
{{
    public class {modelType.Name}Profile : Profile
    {{
        public {modelType.Name}Profile()
        {{
            CreateMap<{modelType.Name}, {modelType.Name}ViewModel>();
            CreateMap<{modelType.Name}ViewModel, {modelType.Name}>();
        }}
    }}
}}";

            string filePath = Path.Combine(_basePath, "Mappings", $"{modelType.Name}Profile.cs");
            File.WriteAllText(filePath, profileCode);
        }

        private string GetViewModelPropertyType(Type propertyType)
        {
            if (propertyType == typeof(int) || propertyType == typeof(long) || propertyType == typeof(short))
                return propertyType.Name;
            if (propertyType == typeof(string))
                return propertyType.Name;
            if (propertyType == typeof(DateTime))
                return propertyType.Name + "?";
            if (propertyType == typeof(bool))
                return propertyType.Name;
            if (propertyType == typeof(decimal) || propertyType == typeof(float) || propertyType == typeof(double))
                return propertyType.Name + "?";

            return propertyType.Name + "?";
        }

        private string AddSpacesToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }

        private void EnsureDirectoryExists(string filePath)
        {
            string directoryName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
        }
    }
}