using CircleMover;

var radius = 400f;
var steps = 1000f;
var step = (Math.PI * 2) / steps;
var time = 1;
var timeStep = time / steps;
var sleepTime = TimeSpan.FromSeconds(timeStep);

while (true)
{
    while (!InputOutput.IsPressed(InputOutput.VirtualKeyStates.VK_F1))
        Thread.Sleep(10);
    if (!InputOutput.TryGetCursorPosition(out var originalPos))
        throw new Exception("Cannot find cursor position.");
    
    InputOutput.Move(radius, 0);
    Thread.Sleep(10);
    InputOutput.LeftDown();
    
    try
    {
        for (var rad = 0d; rad < Math.PI * 4; rad += step)
        {
            if (!InputOutput.TryGetCursorPosition(out var currentPos))
                throw new Exception("Cannot find cursor position");

            var nx = radius * Math.Cos(rad) + originalPos.X;
            var ny = radius * Math.Sin(rad) + originalPos.Y;

            var dx = nx - currentPos.X;
            var dy = ny - currentPos.Y;

            InputOutput.Move(dx, dy);
            var now = DateTime.UtcNow;
            while (DateTime.UtcNow - now < sleepTime)
            {
            }
        }
    }
    finally
    {
        InputOutput.LeftUp();
    }
}
 