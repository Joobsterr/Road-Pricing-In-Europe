using Cassandra;
using DataService.DTO;

namespace DataService
{
    public class DataRepository : IDataRepository
    {
        private Cluster Cluster;
        private Cassandra.ISession WriteSession;

        public DataRepository()
        {
            string user = "cassandra";
            string pwd = "cassandra";

            QueryOptions queryOptions = new QueryOptions().SetConsistencyLevel(ConsistencyLevel.One);


            Cluster cluster = Cluster.Builder()
                .AddContactPoints("127.0.0.1")
                .WithCredentials(user, pwd)
                .WithQueryOptions(queryOptions)
                .Build();

            Cluster = cluster;
            WriteSession = cluster.Connect();
        }

        public void enterDataPoint(List<DataModel> dataModels)
        {
            foreach (DataModel dataModel in dataModels)
            {
                // Format data for database
                var latitude = dataModel.lat_long.Item1.ToString().Replace(",", ".");
                var longitude = dataModel.lat_long.Item2.ToString().Replace(",", ".");
                var timeStamp = dataModel.dateTimeStamp.ToString("yyyy-MM-ddTHH:mm:ss");

                string query = "INSERT INTO sumo.datapoints (car_id, lat_long, time_stamp, route_id, lane_max_speed_ms)" +
                    "VALUES(" + dataModel.carId + ",(" + latitude + "," + longitude + "),'" + timeStamp + "', " + dataModel.routeId + ", " + dataModel.laneMaxSpeedMs + ");";

                WriteSession.Execute(query);
            }
        }

        public List<DataModel> getAllDataPoints()
        {
            var session = Cluster.Connect();

            string query = "SELECT * FROM sumo.datapoints;";

            RowSet rowset = session.Execute(query);

            List<DataModel> dataPoints = new List<DataModel>();
            foreach (var row in rowset)
            {
                DataModel dataModel = new DataModel(
                    row.GetValue<int>("car_id"),
                    row.GetValue<Tuple<Double, Double>>("lat_long"),
                    row.GetValue<DateTime>("time_stamp"),
                    row.GetValue<int>("route_id"),
                    row.GetValue<double>("lane_max_speed_ms")); ;

                dataPoints.Add(dataModel);
            }

            return dataPoints;
        }

        public List<DataModel> getDataPointsPerCar(int carId)
        {
            var session = Cluster.Connect();

            string query = "SELECT * FROM sumo.datapoints WHERE car_id = " + carId + ";";

            RowSet rowset = session.Execute(query);

            List<DataModel> dataPoints = new List<DataModel>();
            foreach (var row in rowset)
            {
                DataModel dataModel = new DataModel(
                    row.GetValue<int>("car_id"),
                    row.GetValue<Tuple<Double, Double>>("lat_long"),
                    row.GetValue<DateTime>("time_stamp"),
                    row.GetValue<int>("route_id"),
                    row.GetValue<double>("lane_max_speed_ms")); ;

                dataPoints.Add(dataModel);
            }

            return dataPoints;
        }

        public List<DataModel> getDataPointsPerCarWithTimeframe(int carId, DateTime startDate, DateTime endDate)
        {
            var session = Cluster.Connect();

            var startDateString = startDate.ToString("yyyy-MM-ddTHH:mm:ss");
            var endDateString = endDate.ToString("yyyy-MM-ddTHH:mm:ss");

            string query = "SELECT * FROM sumo.datapoints WHERE car_id = " + carId + " AND time_stamp > '" + startDateString + "' AND time_stamp < '" + endDateString + "';";

            RowSet rowset = session.Execute(query);

            List<DataModel> dataPoints = new List<DataModel>();
            foreach (var row in rowset)
            {
                DataModel dataModel = new DataModel(
                    row.GetValue<int>("car_id"),
                    row.GetValue<Tuple<Double, Double>>("lat_long"),
                    row.GetValue<DateTime>("time_stamp"),
                    row.GetValue<int>("route_id"),
                    row.GetValue<double>("lane_max_speed_ms")); ;

                dataPoints.Add(dataModel);
            }

            return dataPoints;
        }

        private DataModel createDataModel(Row row)
        {
            return new DataModel(
                    row.GetValue<int>("car_id"),
                    row.GetValue<Tuple<Double, Double>>("lat_long"),
                    row.GetValue<DateTime>("time_stamp"),
                    row.GetValue<int>("route_id"),
                    row.GetValue<double>("lane_max_speed_ms")); ;
        }
    }
}
