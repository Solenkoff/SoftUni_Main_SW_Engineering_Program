"""
A simple calculator module with basic arithmetic operations.
"""

def add(x, y):
    """Adds two numbers."""
    return x + y

def subtract(x, y):
    """Subtracts second number from the first."""
    return x - y

def multiply(x, y):
    """Multiplies two numbers."""
    return x * y

def divide(x, y):
    """
    Divides first number by the second.
    Raises ValueError if the divisor is zero.
    """
    if y == 0:
        raise ValueError("Cannot divide by zero!")
    return x / y
if __name__ == "__main__":
    num1 = 10
    num2 = 5

    print(f"{num1} + {num2} = {add(num1, num2)}")
    print(f"{num1} - {num2} = {subtract(num1, num2)}")
    print(f"{num1} * {num2} = {multiply(num1, num2)}")

    try:
        print(f"{num1} / {num2} = {divide(num1, num2)}")
    except ValueError as e:
        print(e)

    num3 = 0
    try:
        print(f"{num1} / {num3} = {divide(num1, num3)}")
    except ValueError as e:
        print(e)
