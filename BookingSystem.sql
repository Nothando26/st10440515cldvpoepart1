USE master;

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EventBooking')
    DROP DATABASE EventBooking;

CREATE DATABASE EventBooking;
USE EventBooking;

CREATE TABLE Venues (
    VenueID INT IDENTITY(1,1) PRIMARY KEY,
    VenueName VARCHAR(255) NOT NULL,
    Location VARCHAR(255) NOT NULL,
    Capacity INT NOT NULL,
    ImageURL VARCHAR(500)
);

CREATE TABLE Events (
    EventID INT IDENTITY(1,1) PRIMARY KEY,
    EventName VARCHAR(255) NOT NULL,
    EventDate DATE NOT NULL,
    Description TEXT,
    VenueID INT,
    CONSTRAINT FK_Event_Venue FOREIGN KEY (VenueID) REFERENCES Venues(VenueID) ON DELETE CASCADE
);

CREATE TABLE Bookings (
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    VenueID INT,
    EventID INT,
    BookingDate DATE NOT NULL,
    CONSTRAINT FK_Booking_Venue FOREIGN KEY (VenueID) REFERENCES Venues(VenueID) ON DELETE NO ACTION,
    CONSTRAINT FK_Booking_Event FOREIGN KEY (EventID) REFERENCES Events(EventID) ON DELETE NO ACTION
);

INSERT INTO Venues (VenueName, Location, Capacity, ImageURL)
VALUES 
    ('Sun City', 'North West', 20000, 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.getyourguide.nl%2Fnatuurreservaat-pilanesberg-l87269%2Fvanuit-johannesburg-sun-city-resort-dagtour-t669836%2F&psig=AOvVaw3IYAUVucF7mD2_TnKTDzTS&ust=1744133305377000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCJivzYO5xowDFQAAAAAdAAAAABAE'),
    ('City Center Arena', 'Cape Town', 2000, 'https://www.google.com/url?sa=i&url=https%3A%2F%2Ftownlift.com%2F2024%2F04%2Fmore-details-of-utah-nhl-arena-vision-revealed%2F&psig=AOvVaw0TIjqnPvZBNuvUNLMvuens&ust=1744133444210000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCLDLvNi5xowDFQAAAAAdAAAAABAE'),
    ('JSE', 'Johannesburg', 1000, 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.jse.co.za%2Fnews%2Fnews%2Fsmes-jses-inaugural-development-programme-raise-nearly-r1-billion-and-post-strong&psig=AOvVaw2KXG08NluLEyfBglNJioB2&ust=1744133583951000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCJDm5om6xowDFQAAAAAdAAAAABAE'),
    ('Happy Island', 'Roodepoort', 1500, 'https://www.google.com/url?sa=i&url=https%3A%2F%2Fplek.co.za%2Fproducts%2Fmzansi-happy-island-theme-park_chijiuz2puydlr4riguuw5str0q&psig=AOvVaw0qIYx57npkr7K4uzYUcHL7&ust=1744133682349000&source=images&cd=vfe&opi=89978449&ved=0CBUQjRxqFwoTCMDo1ra6xowDFQAAAAAdAAAAABAE');

INSERT INTO Events (EventName, EventDate, Description, VenueID)
VALUES 
    ('Music Concert', '2025-06-15', 'A live music event featuring top artists.', 1),
    ('Tech Conference', '2025-09-22', 'Annual technology summit.', 2),
    ('Mufasa night', '2025-05-04', 'A night to embrace Mufasa.', 3),
    ('Cooking classes', '2025-05-29', 'Come learn new cooking skills', 4);

INSERT INTO Bookings (VenueID, EventID, BookingDate)
VALUES 
    (1, 1, '2025-06-10'),
    (2, 2, '2025-09-15'),
    (4, 3, '2025-09-18'),
    (4, 4, '2025-09-14');

SELECT * FROM Venues;
SELECT * FROM Events;
SELECT * FROM Bookings;
