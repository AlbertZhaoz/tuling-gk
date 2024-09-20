using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace WpfToolKitDemo.ViewModels;

public partial class TulingViewModel : ObservableRecipient
    , IRecipient<ValueChangedMessage<string>>
    , IRecipient<ValueChangedMessage<int>>
{
    public void Receive(ValueChangedMessage<string> message)
    {
        message.Value.ToString();
    }

    public void Receive(ValueChangedMessage<int> message)
    {
        message.Value.ToString();
    }
}


public partial class MessengersDemoViewModel:ObservableObject
{
    [ObservableProperty]
    string _name = "albertzhao";


    partial void OnNameChanged(string value)
    {
        WeakReferenceMessenger.Default.Send(new PropertyChangedMessage<string>(
            this,nameof(Name),default,value)
            );
    }

    [ObservableProperty]
    string _subName="tuling";

    [RelayCommand]
    void Submit()
    {
        Name="tulingchange";

        // 消息发送
        // ValueChangedMessage RequestMessage PropertyChangedMessage
        // WeakReferenceMessenger.Default.Send(new MyMessage("Hello World"),"tokenA");
        WeakReferenceMessenger.Default.Send(new ValueChangedMessage<string>("Hello World"),"tokenA");

        var res1 = WeakReferenceMessenger.Default.Send(new RequestMessage<string>(),"tokenA");

        if (res1.HasReceivedResponse)
        {
            SubName = res1.Response.ToString();
        }
        
    }

    public MessengersDemoViewModel()
    {
        // WeakReferenceMessenger.Default.Register<MyMessage,string>(this,"tokenA",(_,message)=>{ 
        //     Name = message.Content;
        //     });   
        // WeakReferenceMessenger.Default.Register<MyMessage,string>(this,"tokenB",(_,message)=>{ 
        //     Name = message.Content;
        // });   
        // WeakReferenceMessenger.Default.Register<ValueChangedMessage<string>,string>(this,"tokenA",(_,message)=>{ 
        //     Name = message.Value;
        // });  

        // WeakReferenceMessenger.Default.Register<RequestMessage<string>,string>(this,"tokenA",(_,message)=>{ 
        //     message.Reply("Nice to meet you!");
        // });  

        WeakReferenceMessenger.Default.Register<PropertyChangedMessage<string>>(this,(_,message)=>{
                SubName = $"{message.PropertyName}--{message.Sender.GetType().Name} received.";
            });
    }
}

// public record MyMessage(string Content);