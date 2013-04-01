using FubuMVC.Core;

namespace ToDoList
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
	        Actions.IncludeClassesSuffixedWithController();

	        Routes
						.IgnoreControllerNamesEntirely()
						.IgnoreControllerNamespaceEntirely()
						.HomeIs<ToDoListController>(x => x.ToDoList());
        }
    }
}