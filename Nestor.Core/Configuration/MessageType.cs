namespace Nestor.Core.Configuration
{
    public enum MessageType
    {
        // One message with image, text in the description
        // Link to the google maps is in the text
        Image,

        // Two messages, text and location
        // No link to the google maps
        Location
    }
}