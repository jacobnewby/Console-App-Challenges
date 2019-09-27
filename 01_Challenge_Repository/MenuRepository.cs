using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Challenge_Repository
{
    public class MenuRepository
    {
        List<Menu> _menuList = new List<Menu>();

        public void AddToMenu(Menu content)
        {
            _menuList.Add(content);
        }

        public List<Menu> GetMenuList()
        {
            return _menuList;
        }

        public void RemoveContentFromMenuList(int mealNumber)
        {
            foreach (Menu content in _menuList)
            {
                if (content.MealNumber == mealNumber)
                {
                    _menuList.Remove(content);
                    break;
                }
            }
        }

        public void SeedList()
        {
            Menu contentOne = new Menu(1, "McChicken", "It's alright", "You don't want to know", 1.89m);
            Menu contentTwo = new Menu(2, "McDouble", "It's alright", "You don't want to know", 1.89m);

            AddToMenu(contentOne);
            AddToMenu(contentTwo);
        }

        public Menu GetMenuItemById(int userChoice)
        {
            foreach (Menu content in _menuList)
            {
                if(userChoice == content.MealNumber)
                {
                    return content;
                }
            }
                return null;
        }
    }
}
