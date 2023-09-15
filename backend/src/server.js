const express = require('express');
const app = express();
const port = process.env.PORT || 3000;
const authRoutes = require('./routes/authRoutes');
const userRoutes = require('./routes/userRoutes');
const db = require('./config/db');

// Middleware
app.use(express.json());

// Routes
app.use('/auth', authRoutes);
app.use('/user', userRoutes);

// Database sync (create tables)
db.sync()
  .then(() => {
    console.log('Database connected');
    app.listen(port, () => {
      console.log(`Server is running on port ${port}`);
    });
  })
  .catch((err) => console.error('Database connection error:', err));
