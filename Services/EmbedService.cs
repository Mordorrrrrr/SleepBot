#region

using Discord;

#endregion

namespace DiscordBOT.Services
{
    public class EmbedService
    {
        private static readonly EmbedBuilder Eb = new EmbedBuilder();

        public static Embed InfoBuilder(string title, string description, Color color = default(Color))
        {
            if (color.Equals(default(Color))) color = Color.Blue;
            Eb.WithTitle($":information_source: {title}")
                .WithDescription(description)
                .WithColor(color);
            return Eb.Build();
        }

        public static Embed SuccesBuilder(string description, Color color = default(Color))
        {
            if (color.Equals(default(Color))) color = Color.Green;
            Eb.WithTitle(":white_check_mark: SUCCESS")
                .WithDescription(description)
                .WithColor(color);
            return Eb.Build();
        }

        public static Embed ErrorBuilder(string description, Color color = default(Color))
        {
            if (color.Equals(default(Color))) color = Color.Red;
            Eb.WithTitle(":no_entry: ERROR")
                .WithDescription(description)
                .WithColor(color);
            return Eb.Build();
        }

        public static Embed LogBuilder(string title, string description, Color color = default(Color))
        {
            if (color.Equals(default(Color))) color = Color.Gold;
            Eb.WithTitle(title)
                .WithDescription(description)
                .WithColor(color);
            return Eb.Build();
        }
    }
}