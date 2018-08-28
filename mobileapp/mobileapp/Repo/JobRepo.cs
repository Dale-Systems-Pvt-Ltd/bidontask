using mobileapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Maps;

namespace mobileapp.Repo
{
    public interface IJobRepo
    {
        IList<JobMapPin> GetJobMapPinsInRegion(MapSpan span, int[] excludeIds);
    }
    public class JobRepo : IJobRepo
    {
        public IList<JobMapPin> GetJobMapPinsInRegion(MapSpan span, int[] excludeIds)
        {
            var bottomleft = GetMapVisibleSouthWest(span);
            Console.WriteLine("bottomleft " + bottomleft.Latitude + " " + bottomleft.Longitude);

            var topright = GetMapVisibleNorthEast(span);
            Console.WriteLine("topright " + topright.Latitude + " " + topright.Longitude);
            var list = GetTestData();
            var retVal = list.Where(x => x.Latitude >= bottomleft.Latitude && x.Longitude >= bottomleft.Longitude
                           && x.Latitude <= topright.Latitude && x.Longitude <= topright.Longitude
                           && !excludeIds.Contains(x.Id));


            return retVal.ToList();
        }

        private IList<JobMapPin> GetTestData()
        {
            var list = new List<JobMapPin>();

            list.Add(new JobMapPin
            {
                Id = 1,
                Name = "Fix Kitchen Tap",
                Description = "Budget: CA$100",
                Latitude = 18.5488557256773,
                Longitude = 73.7687325105071
            });

            //18.4898212581756 73.7386344373226
            list.Add(new JobMapPin
            {
                Id = 2,
                Name = "Croatian Language Study Tutor",
                Description = "CA$15",
                Latitude = 18.4898212581756,
                Longitude = 73.7386344373226
            });

            list.Add(new JobMapPin
            {
                Id = 3,
                Name = "Assemble my new flat bed furniture",
                Description = "CA$15",
                Latitude = 18.4278470934358,
                Longitude = 73.7093259394169
            });

            list.Add(new JobMapPin
            {
                Id = 4,
                Name = "Collect menu from Praya Thai Restaurant",
                Description = "CA$15",
                Latitude = 18.549114780935,
                Longitude = 73.6771803349257
            });



            return list;
        }

        public bool ContainsInVisibleRegion(Position position, Position bottomLeft, Position topRight)
        {
            var rect = new System.Drawing.RectangleF((float)bottomLeft.Latitude, (float)bottomLeft.Longitude,
                (float)(topRight.Latitude - bottomLeft.Latitude), (float)(topRight.Longitude - bottomLeft.Longitude));

            var point = new System.Drawing.PointF((float)position.Latitude, (float)position.Longitude);
            return rect.Contains(point);

        }

        public Position GetMapVisibleSouthWest(MapSpan mapSpan)
        {
            var halfHeightDegrees = mapSpan.LatitudeDegrees / 2;
            var halfWidthDegrees = mapSpan.LongitudeDegrees / 2;

            var left = mapSpan.Center.Longitude - halfWidthDegrees;
            var bottom = mapSpan.Center.Latitude - halfHeightDegrees;
            return new Position(bottom, left);
        }

        public Position GetMapVisibleNorthEast(MapSpan mapSpan)
        {
            var halfHeightDegrees = mapSpan.LatitudeDegrees / 2;
            var halfWidthDegrees = mapSpan.LongitudeDegrees / 2;

            var right = mapSpan.Center.Longitude + halfWidthDegrees;
            var top = mapSpan.Center.Latitude + halfHeightDegrees;
            return new Position(top, right);
        }

    }
}
