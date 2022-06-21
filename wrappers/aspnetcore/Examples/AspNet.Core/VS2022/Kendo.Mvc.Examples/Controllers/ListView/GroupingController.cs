using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ListViewController : BaseController
    {
        [Demo]
        public ActionResult Grouping()
        {
            return View();
        }
        public ActionResult Grouping_Read([DataSourceRequest] DataSourceRequest request)
        {
            string destinations = @"[
            {
                'Country': 'Belgium',
                'Title': 'BRUSSELS, BELGIUM',
                'Description': 'Chocolate, beer, music and surrealism.',
                'ImageUrl': 'brussels-180x150.png'
            },
            {
                'Country': 'Portugal',
                'Title': 'PORTO, PORTUGAL',
                'Description': 'Taste it, drink it, eat it, love it. Bem-vindo ao Porto!',
                'ImageUrl': 'porto-180x150.png'
            },
            {
                'Country': 'Spain',
                'Title': 'MALAGA, SPAIN',
                'Description': 'Enjoy the perfect climat.',
                'ImageUrl': 'malaga-180x150.png'
            },
            {
                'Country': 'Hungary',
                'Title': 'BUDAPEST, HUNGARY',
                'Description': 'One of the most exciting cities in the world.',
                'ImageUrl': 'budapest-180x150.png'
            },
            {
                'Country': 'Slovakia',
                'Title': 'BRATISLAVA, SLOVAKIA',
                'Description': 'A modern city on the Danube.',
                'ImageUrl': 'bratislava-180x150.png'
            },
            {
                'Country': 'Italy',
                'Title': 'FLORENCE, ITALY',
                'Description': 'Love and culture are everywhere!',
                'ImageUrl': 'florence-180x150.png'
            },
            {
                'Country': 'Poland',
                'Title': 'POZNAN, POLAND',
                'Description': 'A unique heritage with rich cultural offer.',
                'ImageUrl': 'poznan-180x150.png'
            },
            {
                'Country': 'Greece',
                'Title': 'ATHENS, GREECE',
                'Description': 'The biggest open-air museum in Europe.',
                'ImageUrl': 'athens-180x150.png'
            },
            {
                'Country': 'Bulgaria',
                'Title': 'SOFIA, BULGARIA',
                'Description': 'One of Europe`s oldest cities.',
                'ImageUrl': 'sofia-180x150.png'
            },
            {
                'Country': 'France',
                'Title': 'BORDEAUX, FRANCE',
                'Description': 'Discover exciting new facets of its character.',
                'ImageUrl': 'bordeaux-180x150.png'
            },
            {
                'Country': 'Switzerland',
                'Title': 'GENEVA, SWITZERLAND',
                'Description': 'One of the most welcoming cities in Europe.',
                'ImageUrl': 'geneva-180x150.png'
            },
            {
                'Country': 'Latvia',
                'Title': 'RIGA, LATVIA',
                'Description': 'At the crossroads of various nations and cultures.',
                'ImageUrl': 'riga-180x150.png'
            },
            {
                'Country': 'Span',
                'Title': 'SEVILLE, SPAIN',
                'Description': 'Seville. Any time of year…',
                'ImageUrl': 'seville-180x150.png'
            },
            {
                'Country': 'France',
                'Title': 'COLMAR, FRANCE',
                'Description': 'A condensed version of the Alsace region.',
                'ImageUrl': 'colmar-180x150.png'
            },
            {
                'Country': 'Austria',
                'Title': 'VIENNA, AUSTRIA',
                'Description': 'The Giant Ferris Wheel is awaiting you.',
                'ImageUrl': 'vienna-180x150.png'
            },
            {
                'Country': 'France',
                'Title': 'MONTPELLIER, FRANCE',
                'Description': 'Smart, Mediterranean, attractive, welcoming and festive.',
                'ImageUrl': 'montpellier-180x150.png'
            },
            {
                'Country': 'Spain',
                'Title': 'VALENCIA, SPAIN',
                'Description': 'Sun, culture, history and future. ',
                'ImageUrl': 'valencia-180x150.png'
            },
            {
                'Country': 'Spain',
                'Title': 'BARCELONA, SPAIN',
                'Description': 'Barcelona never sleeps.',
                'ImageUrl': 'barcelona-180x150.png'
            },
            {
                'Country': 'Italy',
                'Title': 'MILAN, ITALY',
                'Description': 'The hub of Italian culture',
                'ImageUrl': 'milan-180x150.png'
            },
            {
                'Country': 'Poland',
                'Title': 'GDANSK, POLAND',
                'Description': 'You`ll be amazed by the beauty of Gdansk.',
                'ImageUrl': 'gdansk-180x150.png'
            },
            {
                'Country': 'Italy',
                'Title': 'ROME, ITALY',
                'Description': 'Treat yourself to a stay in the Eternal City.',
                'ImageUrl': 'rome-180x150.png'
            },
            {
                'Country': 'Scotland',
                'Title': 'EDINBURGH, SCOTLAND',
                'Description': 'Shopping, dining & architectural splendour.',
                'ImageUrl': 'edinburgh-180x150.png'
            },
            {
                'Country': 'Portugal',
                'Title': 'LISBON, PORTUGAL',
                'Description': 'The pure pleasure of being in one of the best cities in the world.',
                'ImageUrl': 'lisbon-180x150.png'
            }
        ]";

            var result = JsonConvert.DeserializeObject<List<DestinationViewModel>>(destinations);
            return Json(result.ToDataSourceResult(request));
        }
    }
}