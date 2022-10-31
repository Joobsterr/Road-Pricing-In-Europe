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

        public void enterDataPoint(DataModel jsonMessage)
        {
            // Format data for database
            var latitude = jsonMessage.lat_long.Item1.ToString().Replace(",", ".");
            var longitude = jsonMessage.lat_long.Item2.ToString().Replace(",", ".");
            var timeStamp = jsonMessage.dateTimeStamp.ToString("yyyy-MM-ddTHH:mm:ss");

            string query = "INSERT INTO sumo.datapoints (id, car_id, lat_long, time_stamp)" +
                "VALUES(" + jsonMessage.id + "," + jsonMessage.carId + ",(" + latitude + "," + longitude + "),'" + timeStamp + "');";

            WriteSession.Execute(query);
        }

        public List<DataModel> getAllDataPoints()
        {
            var session = Cluster.Connect();
            RowSet rowset = session.Execute("SELECT * FROM sumo.datapoints;");

            List<DataModel> dataPoints = new List<DataModel>();
            foreach (var row in rowset)
            {
                DataModel dataModel = new DataModel(
                    row.GetValue<Guid>("id"),
                    row.GetValue<int>("car_id"),
                    row.GetValue<Tuple<Double, Double>>("lat_long"),
                    row.GetValue<DateTime>("time_stamp")); ;

                dataPoints.Add(dataModel);
            }

            return dataPoints;
        }

        public List<DataModel> getDataPointsPerCar(int carId)
        {
            var session = Cluster.Connect();
            RowSet rowset = session.Execute("SELECT * FROM sumo.datapoints WHERE car_id = " + carId + " ALLOW FILTERING;");

            List<DataModel> dataPoints = new List<DataModel>();
            foreach (var row in rowset)
            {
                DataModel dataModel = new DataModel(
                    row.GetValue<Guid>("id"),
                    row.GetValue<int>("car_id"),
                    row.GetValue<Tuple<Double, Double>>("lat_long"),
                    row.GetValue<DateTime>("time_stamp")); ;

                dataPoints.Add(dataModel);
            }

            return dataPoints;
        }
    }
}
