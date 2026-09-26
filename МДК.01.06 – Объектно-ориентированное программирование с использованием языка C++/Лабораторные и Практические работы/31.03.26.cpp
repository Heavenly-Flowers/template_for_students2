#include <iostream>
#include <limits>
#include <stdexcept>

class Fraction {
private:
    int numerator;
    int denominator;

    // Алгоритм Евклида для нахождения НОД.
    static long long gcd(long long a, long long b) {
        if (a < 0) a = -a;
        if (b < 0) b = -b;

        while (b != 0) {
            long long remainder = a % b;
            a = b;
            b = remainder;
        }
        return a;
    }

    // Промежуточные вычисления выполняются в long long,
    // а поля готовой дроби остаются int, как требуется в задании.
    static Fraction fromValues(long long n, long long d) {
        if (d == 0) {
            throw std::invalid_argument("Знаменатель не может быть равен 0.");
        }

        long long divisor = gcd(n, d);
        n /= divisor;
        d /= divisor;

        // Знак дроби хранится в числителе.
        if (d < 0) {
            n = -n;
            d = -d;
        }

        if (n < std::numeric_limits<int>::min() ||
            n > std::numeric_limits<int>::max() ||
            d > std::numeric_limits<int>::max()) {
            throw std::overflow_error("Результат не помещается в поля типа int.");
        }

        Fraction result;
        result.numerator = static_cast<int>(n);
        result.denominator = static_cast<int>(d);
        return result;
    }

public:
    Fraction() : numerator(0), denominator(1) {}

    Fraction(int n, int d) {
        *this = fromValues(n, d);
    }

    void print() {
        std::cout << numerator << '/' << denominator;
    }

    Fraction operator+(const Fraction& other) {
        return fromValues(
            static_cast<long long>(numerator) * other.denominator +
                static_cast<long long>(other.numerator) * denominator,
            static_cast<long long>(denominator) * other.denominator);
    }

    Fraction operator-(const Fraction& other) {
        return fromValues(
            static_cast<long long>(numerator) * other.denominator -
                static_cast<long long>(other.numerator) * denominator,
            static_cast<long long>(denominator) * other.denominator);
    }

    Fraction operator*(const Fraction& other) {
        return fromValues(
            static_cast<long long>(numerator) * other.numerator,
            static_cast<long long>(denominator) * other.denominator);
    }

    Fraction operator/(const Fraction& other) {
        if (other.numerator == 0) {
            throw std::invalid_argument("Деление на нулевую дробь невозможно.");
        }
        return fromValues(
            static_cast<long long>(numerator) * other.denominator,
            static_cast<long long>(denominator) * other.numerator);
    }

    void simplify() {
        *this = fromValues(numerator, denominator);
    }

    bool operator==(const Fraction& other) {
        // Дроби всегда хранятся сокращёнными с положительным знаменателем.
        return numerator == other.numerator && denominator == other.denominator;
    }

    friend std::ostream& operator<<(std::ostream& os, const Fraction& f) {
        return os << f.numerator << '/' << f.denominator;
    }
};

int main() {
    try {
        Fraction zero;
        Fraction f1(1, 2);
        Fraction f2(3, 4);

        std::cout << "Fraction(): " << zero << '\n';
        std::cout << "f1 = ";
        f1.print();
        std::cout << "\nf2 = " << f2 << '\n';

        Fraction sum = f1 + f2;
        std::cout << "f1 + f2 = " << sum << '\n';
        std::cout << "f1 - f2 = " << f1 - f2 << '\n';
        std::cout << "f1 * f2 = " << f1 * f2 << '\n';
        std::cout << "f1 / f2 = " << f1 / f2 << '\n';

        Fraction f3(6, 8);
        f3.simplify();
        std::cout << "6/8 = " << f3 << '\n';
        std::cout << "1/(-2) = " << Fraction(1, -2) << '\n';
        std::cout << std::boolalpha;
        std::cout << "1/2 == 3/4: " << (f1 == f2) << '\n';
        std::cout << "3/4 == 6/8: " << (f2 == f3) << '\n';

        // Ошибки перехватываются, чтобы вывести сообщение и продолжить работу.
        try {
            Fraction invalid(1, 0);
            std::cout << invalid << '\n';
        } catch (const std::invalid_argument& error) {
            std::cout << "Ошибка: " << error.what() << '\n';
        }

        try {
            std::cout << f1 / zero << '\n';
        } catch (const std::invalid_argument& error) {
            std::cout << "Ошибка: " << error.what() << '\n';
        }
    } catch (const std::exception& error) {
        std::cerr << "Ошибка: " << error.what() << '\n';
        return 1;
    }

    return 0;
}
