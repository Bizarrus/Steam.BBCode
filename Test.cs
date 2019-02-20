using System;
using System.Collections.Generic;
using System.Text;
using Steam.BBCode.Components;

namespace Steam.BBCode {
    class Test {
        public static void Main(string[] args) {
            BBCode code = new BBCode();
            List<Component> components = code.Parse(
                    "[img]https://steamcdn-a.akamaihd.net/steamcommunity/public/images/clans/6835324/167b13506676680e41042044448221e875d49586.png[/img] Originally posted on the official forums by Bigfoot: Hello everyone! It’s been a while since I’ve made a post here, I’d like to share with you our plans for 2019, which are extensive! [b]First, I’d like to recap what happened in 2017/2018:[/b] In 2017 we launched the Forge, and followed it up in 2018 with the Gorge. The idea was that we could offer a new way of playing Don’t Starve Together, in a limited-time format. We were a bit burned out on creating DST core game content and this format allowed us to try something a bit different, so we made these crazy game modes and provided them to the community for free. Every time we launched these events, tons of players came to play, and in every instance we hit our highest ever DST concurrency. We’re super thrilled that so many people came to play the our weird game events! While we enjoyed the events and are happy with the result, there were some drawbacks: [list][*]They took WAY longer to make than we expected, so we weren’t able to make as much content as we wanted, and it left little time to do things like bug fixes and Quality of Life updates for the base game. [*]Because we run the servers for these events, we also incurred the cost of these servers. Those of you who have been here a while know that Don’t Starve was not architected to be a multiplayer game, so running them on our servers was extremely inefficient. In short, even though we loved that everyone came to play, the item sales were only barely covering the costs of the servers. [*]We found that it was exceedingly difficult for us to run these events on console and as such underserved our console players.[/list] It has been a valuable experience and we think the game is better for it, however we feel that it’s time that we turn our attention back to the core Don’t Starve Together experience: surviving together. Here’s what we’re doing for 2019: [h1]Brand New Content[/h1] The team is now working on brand new content for Don’t Starve Together. Survivors will be able to travel to new lands with new biomes, creatures, and more. The first drop of this new content will come in mid-April, and we will continually be adding to the content every couple months afterward. As we said before, we think it’s important that everyone can play together and we don’t segregate our audience, so all of this content will be available for free to everyone! [img]https://steamcdn-a.akamaihd.net/steamcommunity/public/images/clans/6835324/167b13506676680e41042044448221e875d49586.png[/img] [h1]Character Refreshes[/h1] The team also felt it was high time we gave our core cast some love (yes, we heard you). Over the course of the next year, we will be bestowing every character with revamped abilities, and give a glimpse into their backstory. Our goals here are to make each character unique, interesting and valuable in their own right and we expect this to be game changing in many ways. [img]https://steamcdn-a.akamaihd.net/steamcommunity/public/images/clans/6835324/812a3cf89e3975eae33ad29daa1a5c17a13934ec.jpg[/img] Starting in March with Winona, we will be releasing a character refresh once a month. These character refreshes will again be free to all players, and we will be selling new skins for these characters on the month they are refreshed. In addition, the Triumphant, Guest of Honor and Survivor skin packs will be available to purchase for the character on that date. All owners of these skins prior to that date will be upgraded to an “Heirloom” rarity, with a higher unraveling value. [h1]New Characters Enter the Fray[/h1] A fresh batch of four characters have been unwittingly ensnared and brought into the world. These new survivors will be released into the wild starting in Mid-March, and a new one will be released every 2 months [img]https://steamcdn-a.akamaihd.net/steamcommunity/public/images/clans/6835324/fa503b89d330692fc19979172029c8843e7a3cc0.jpg[/img] We are still deciding the final price of these characters, but we currently think they will be $6.99 USD each, which includes a full character skin set. You will also be able to weave the characters with spool. Since we do not want to charge players for the new world content, these new characters will be our main way to fund development of this new content. [h1]Console Development[/h1] We are working hard on keeping the console versions of the game up to date. Specifically, we are investing in technology to allow us to more quickly update the game without going through lengthy certification on every small change, and we've also added more staff to work exclusively on updating the console versions. We're happy to say that the next update for the Year of the Pig King event will launch within 2 days of the PC version. [h1]Quality of Life, Twitch Drops, Etc.[/h1] We will also be continually updating the game with bug fixes, QoL updates, new skins for Twitch drops, and more things that we’re not quite ready to announce yet. Speaking of which, the Year of the Pig King update is going live on Thursday! Long Live the (Pig) King! And that’s it folks! In short, we are significantly increasing our support of Don’t Starve Together in 2019 with new game content, character refreshes, new stories to be told, new characters, and new skins. Thanks so much for playing this crazy game, once again. I’m still amazed at how it’s evolved over the years. Please give us your feedback and thoughts!"
                    +
                    "[url=store.steampowered.com] Link	[/url]"
                   );

            foreach (Component component in components) {

                if (component.GetType() == typeof(Bold)) {
                    Console.WriteLine("BOLD: " + component.GetContent());
                } else if (component.GetType() == typeof(Code)) {
                    Console.WriteLine("CODE: " + component.GetContent());
                } else if (component.GetType() == typeof(Italic)) {
                    Console.WriteLine("ITALIC: " + component.GetContent());
                } else if (component.GetType() == typeof(List)) {
                    List list = (List) component;
                    Console.WriteLine("LIST:");

                    foreach (string item in list.GetItems()) {
                        Console.WriteLine(" >> " + item);
                    }

                } else if (component.GetType() == typeof(NoParse)) {
                    Console.WriteLine("NOPARSE: " + component.GetContent());
                } else if (component.GetType() == typeof(PlainText)) {
                    Console.WriteLine("PLAINTEXT: " + component.GetContent());
                } else if (component.GetType() == typeof(Quote)) {

                    Console.WriteLine("QUOTE: " + component.GetContent());

                } else if (component.GetType() == typeof(Spoiler)) {
                    Console.WriteLine("SPOILER: " + component.GetContent());
                } else if (component.GetType() == typeof(Strike)) {
                    Console.WriteLine("STRIKE: " + component.GetContent());
                } else if (component.GetType() == typeof(Title)) {
                    Console.WriteLine("TITLE: " + component.GetContent());
                } else if (component.GetType() == typeof(Underline)) {
                    Console.WriteLine("UNSERLINE: " + component.GetContent());
                } else if (component.GetType() == typeof(URL)) {
                    URL url = (URL) component;
                    Console.WriteLine("URL: " + url.GetURL() + " (" + url.GetContent() + ")");

                } else if (component.GetType() == typeof(Image)) {
                    Image url = (Image) component;
                    Console.WriteLine("Image: " + url.GetURL());
                }

                Console.WriteLine("");
            }

            Console.ReadKey();
        }
    }
}
