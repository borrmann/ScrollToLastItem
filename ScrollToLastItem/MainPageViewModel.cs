using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ScrollToLastItem
{
    public partial class MainPageViewModel : ObservableObject
    {
        public static List<Message> MessagesSource = new ()
        {
            new Message()
            {
                DateTime = new DateTime(2022,12,1,12 ,20,0),
                Text = "Hello",
                FromMe= true,
            },
            new Message()
            {
                DateTime = new DateTime(2022,12,1,12 ,21,0),
                Text = "Hello, how are you?",
                FromMe= false,
            },
            new Message()
            {
                DateTime = new DateTime(2022,12,1,12 ,22,0),
                Text = "good, thanks, how are you?",
                FromMe= true,
            },
            new Message()
            {
                DateTime = new DateTime(2022,12,1,12 ,23,0),
                Text = "great. Are you free tonight?",
                FromMe= true,
            },
            new Message()
            {
                DateTime = new DateTime(2022,12,1,12 ,24,0),
                Text = "yes, lets hang!",
                FromMe= false,
            },
        };

        private List<Message> messages;
        public IEnumerable<MessagesGrouped> MessagesGrouped => messages?.GroupBy(x => x.DateGroup)?.Select(y => new MessagesGrouped(y.Key, y.ToList()));

        [ObservableProperty]
        private string text;

        public async Task DownloadHistory()
        {
            await Task.Delay(1000);

            messages = new List<Message>(MessagesSource);
            OnPropertyChanged(nameof(MessagesGrouped));
        }

        [RelayCommand]
        private void AddMessage()
        {
            if (string.IsNullOrEmpty(text))
                return;

            Message msg = new ()
            {
                DateTime = DateTime.Now,
                FromMe = true,
                Text = text
            };

            messages.Add(msg);
            OnPropertyChanged(nameof(MessagesGrouped));
        }


    }
}
