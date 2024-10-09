using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eecomerce.Helpers //Самият клас отделя Service-a от Контролера
{
	public class ModelStateWrapper : IValidationDictionary
	{
		private ModelStateDictionary _modelStateDictionary;

		public ModelStateWrapper(ModelStateDictionary modelStateDictionary)
		{
			_modelStateDictionary = modelStateDictionary;
		}

		public void AddError(string key, string errorMessage)
		{
			_modelStateDictionary.AddModelError(key, errorMessage);
		}

		public bool IsValid 
		{ 
			get { return _modelStateDictionary.IsValid; } 
		}
	}
}
