using WPFBlazorChat.Models;

namespace WPFBlazorChat.Services;
public class UserService : IUserService
{
    private List<ChatUserItem>? _user = null;

    public List<ChatUserItem> GetUsers()
    {
        if (_user == null)
        {
            _user = new List<ChatUserItem>()
            {
                new ChatUserItem { Header = "好友列表" },
                new ChatUserItem
                {
                    Avatar = "https://cdn.masastack.com/stack/images/website/masa-blazor/lists/1.png",
                    UserName = "杨过",
                    Memo = "杨过，名过，字改之，是金庸武侠小说《神雕侠侣》的主人公，前作《射雕英雄传》中杨康与穆念慈之子，西毒欧阳锋的义子。名字为郭靖、黄蓉所取。"
                },
                new ChatUserItem
                {
                    Divider = true,
                    Inset = true
                },
                new ChatUserItem
                {
                    Avatar = "https://cdn.masastack.com/stack/images/website/masa-blazor/lists/4.png",
                    UserName = "小龙女",
                    Memo = "容颜绝世、清丽脱俗、美胜天仙、生性冷漠、不谙世事，对待爱情坚贞不悔，一袭白衣若雪，犹似身在烟中雾里。"
                },
                new ChatUserItem
                {
                    Divider = true,
                    Inset = true
                },
                new ChatUserItem
                {
                    Avatar = "https://cdn.masastack.com/stack/images/website/masa-blazor/lists/2.png",
                    UserName = "郭靖",
                    Memo = "郭靖 ，是金庸著武侠小说《射雕英雄传》中的男主角和《神雕侠侣》中的重要角色，《倚天屠龙记》中也曾引述其相关事迹，他是贯通“射雕三部曲”的关键人物之一。"
                },
                new ChatUserItem
                {
                    Divider = true,
                    Inset = true
                },
                new ChatUserItem
                {
                    Avatar = "https://cdn.masastack.com/stack/images/website/masa-blazor/lists/4.png",
                    UserName = "郭襄",
                    Memo = "郭靖和黄蓉的次女，名字出于父母镇守襄阳、保卫大宋的信念，故名“襄”。她善良纯真、豪迈慷慨，风格破俗立新，不存门户阶级观念，喜欢结交江湖中人，人称“小东邪”。"
                },
                new ChatUserItem
                {
                    Divider = true,
                    Inset = true
                },
                new ChatUserItem
                {
                    Avatar = "https://cdn.masastack.com/stack/images/website/masa-blazor/lists/4.png",
                    UserName = "程英",
                    Memo = "和杨过萍水相逢，曾经共抗敌人，在互敬对方是君子和淑女中，动了真情。杨过却对她无心，为了使她死心，与她结义兄妹。她只好终身不嫁，与表妹陆无双相伴一生。"
                }
            };
        }

        return _user;
    }
}