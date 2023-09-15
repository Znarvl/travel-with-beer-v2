// controllers/userController.js

const User = require('../models/User');

const userController = {
  getUser: async (req, res) => {
    try {
      // Retrieve user data from the database
      const user = await User.findOne({ where: { id: req.params.userId } });
      
      if (!user) {
        return res.status(404).json({ error: 'User not found' });
      }

      // Send the user data as a response
      res.json(user);
    } catch (error) {
      console.error(error);
      res.status(500).json({ error: 'Internal server error' });
    }
  },

  updateProfile: async (req, res) => {
    const { userId } = req.params;
    const { username, email, password } = req.body;

    try {
      // Update the user's profile in the database
      await User.update(
        { username, email, password },
        { where: { id: userId } }
      );

      // Send a success message as a response
      res.json({ message: 'User profile updated successfully' });
    } catch (error) {
      console.error(error);
      res.status(500).json({ error: 'Profile update failed' });
    }
  },
  getAllUsers: async (req, res) => {
  try {
    const users = await User.findAll();
    res.json(users);
  } catch (error) {
    console.error(error);
    res.status(500).json({ error: 'Failed to retrieve users' });
  }
}
};

module.exports = userController;
