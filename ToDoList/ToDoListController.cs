using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;

namespace ToDoList
{
	public class ToDoListController
	{
		private int _lastId;
		private ToDoListViewModel _model;


		public ToDoListViewModel ToDoList()
		{
			_model = (ToDoListViewModel)HttpContext.Current.Session[ToDoModel.SessionKey] ?? new ToDoListViewModel();

			return _model;
		}

		[UrlPattern("addToDo/{Description}")]
		public FubuContinuation AddToDo(ToDoModel input)
		{
			_model = (ToDoListViewModel)HttpContext.Current.Session[ToDoModel.SessionKey];
			var toStore = new ToDoModel { Description = input.Description };
			_model.ToDos.Add(toStore);
			HttpContext.Current.Session[ToDoModel.SessionKey] = _model;
			return FubuContinuation.RedirectTo<ToDoListController>(x => x.ToDoList());
		}

		public void get_removeToDoWithId_Id(ToDoModel toDo)
		{
			var toRemove = _model.ToDos.Find(x => x.Id == toDo.Id);
			_model.ToDos.Remove(toRemove);
		}

		private int GetId()
		{
			return ++_lastId;
		}
	}

	public class ToDoListViewModel
	{
		private List<ToDoModel> _toDos;
		public List<ToDoModel> ToDos
		{
			get { return _toDos ?? new List<ToDoModel>(); }
			set { _toDos = value; }
		}
	}

	public class ToDoModel
	{
		public static string SessionKey = "ToDoListSession";
		public int Id { get; set; }
		public string Description { get; set; }
	}
}