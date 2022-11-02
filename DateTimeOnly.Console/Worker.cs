using DateTimeOnly.Data;

namespace DateTimeOnly.Console
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly TestDbContext _context;

        public Worker(ILogger<Worker> logger, TestDbContext context)
        {
            _logger = logger;
            _context = context; 
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var obj = new ClassWithStructs
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                Time = TimeOnly.FromDateTime(DateTime.Now)
            };
            await _context.Structs.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
    }
}
