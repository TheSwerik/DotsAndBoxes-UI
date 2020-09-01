using System.Drawing;

namespace UI.Services.Model
{
    public class Player
    {
        private User User;
        public Color Color;

        public Player(User user)
        {
            User = user;
        }
    }
}