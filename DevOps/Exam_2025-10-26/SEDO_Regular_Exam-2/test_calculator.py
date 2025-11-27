import unittest
import calculator 

class TestCalculator(unittest.TestCase):
    """Unit tests for the calculator module."""

    def test_add(self):
        """Test the add function."""
        self.assertEqual(calculator.add(10, 5), 15)
        self.assertEqual(calculator.add(-1, 1), 0)
        self.assertEqual(calculator.add(-1, -1), -2)
        self.assertEqual(calculator.add(0, 0), 0)
        self.assertAlmostEqual(calculator.add(0.1, 0.2), 0.3) 

    def test_subtract(self):
        """Test the subtract function."""
        self.assertEqual(calculator.subtract(10, 5), 5)
        self.assertEqual(calculator.subtract(-1, 1), -2)
        self.assertEqual(calculator.subtract(-1, -1), 0)
        self.assertEqual(calculator.subtract(0, 0), 0)
        self.assertAlmostEqual(calculator.subtract(0.3, 0.1), 0.2)

    def test_multiply(self):
        """Test the multiply function."""
        self.assertEqual(calculator.multiply(10, 5), 50)
        self.assertEqual(calculator.multiply(-1, 1), -1)
        self.assertEqual(calculator.multiply(-1, -1), 1)
        self.assertEqual(calculator.multiply(0, 5), 0)
        self.assertEqual(calculator.multiply(5, 0), 0)
        self.assertAlmostEqual(calculator.multiply(0.5, 0.5), 0.25)

    def test_divide(self):
        """Test the divide function."""
        self.assertEqual(calculator.divide(10, 5), 2)
        self.assertEqual(calculator.divide(-1, 1), -1)
        self.assertEqual(calculator.divide(-1, -1), 1)
        self.assertEqual(calculator.divide(0, 5), 0)
        self.assertAlmostEqual(calculator.divide(1, 2), 0.5)

        # Test division by zero
        # self.assertRaises(ValueError, calculator.divide, 10, 0)
        # Alternative syntax for assertRaises:
        with self.assertRaises(ValueError):
            calculator.divide(10, 0)

# This allows running the tests directly from the command line
if __name__ == '__main__':
    unittest.main()
