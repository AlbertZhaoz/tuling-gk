<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

class MyDataModel
{
	public List<int>? Data { get; private set; }

	private MyDataModel(){}
	
	public static async Task<MyDataModel> CreateAsync(){
		var dataModel = new MyDataModel();
		await dataModel.LoadDataAsync();
		return dataModel;
	}

	
	async Task LoadDataAsync()
	{
		await Task.Delay(1000);

		Data = Enumerable.Range(1, 10).ToList();
	}
}