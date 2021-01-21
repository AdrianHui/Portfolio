using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class LinqMethods
    {
        public LinqMethods()
        {
        }

        public (int, int) ConsonantAndVowelCounter(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            const string vowels = "aeiou";
            int vowelsCount = text.Count(character => vowels.Contains(character));
            int consonantsCount = text.Length - vowelsCount;
            return (vowelsCount, consonantsCount);
        }

        public char FirstUniqueCharacter(string text)
        {
            return text.GroupBy(x => x, y => y, (key, value) => (key, count: value.Count()))
                .OrderBy(x => x.count).First().key;
        }

        public int ConvertToInt(string text)
        {
            return text.Select(x => (int)char.GetNumericValue(x)).Aggregate((x, y) => x * 10 + y);
        }

        public char MostOccurences(string text)
        {
            return text.GroupBy(x => x, y => y, (key, value) => (key, value.Count()))
                .Max(x => x.key);
        }

        public IEnumerable<string> GetPalindromes(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            var substrings = Enumerable.Range(0, text.Length)
                .SelectMany(x => Enumerable.Range(1, text.Length - x)
                .Select(y => text.Substring(x, y)));
            return substrings.Where(x => x.SequenceEqual(x.Reverse()));
        }

        public IEnumerable GetSubArraysThatEvaluateTo(int[] numbers, int expectedResult)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers");
            }

            var sub = Enumerable.Range(0, numbers.Length - 1)
                .SelectMany(x => Enumerable.Range(2, numbers.Length - x - 1)
                .Select(y => numbers.Skip(x).Take(y)));
            return sub.Where(y => y.Sum() <= expectedResult);
        }

        public IEnumerable GenerateExpressionsThatHitTarget(int n, int k)
        {
            const string operators = "+-";
            IEnumerable<string> combinations = new[] { "" };
            return Enumerable.Range(1, n).Aggregate(
                    combinations, (seed, v) => seed.SelectMany(
                            y => operators.Select(z => y + z)))
                    .Select(x => x.Select((z, y) => z == '+' ? y + 1 : (y + 1) * -1))
                    .Where(x => x.Sum() <= k);
        }

        public IEnumerable GetPythagoreanNumbers(int[] numbers)
        {
            var triplets = numbers.SelectMany(
                (x, i) => numbers.SelectMany(
                (y, j) => numbers.Select(
                (z, k) => i == j || i == k || j == k ? null : new[] { x, y, z })));
            return triplets.Where(x => x != null && x[0] * x[0] + x[1] * x[1] == x[2] * x[2]);
        }

        public IEnumerable ProductsThatHaveAtLeastAFeatureInCommon(
            ICollection<Product> products, ICollection<Feature> features)
        {
            return products.Where(x => x.Features.Intersect(features).Any());
        }

        public IEnumerable ProductsThatHaveAllFeatures(
            ICollection<Product> products, ICollection<Feature> features)
        {
            return products.Where(x => x.Features.Intersect(features).Count() == features.Count);
        }

        public IEnumerable ProductsThatDontHaveAnyFeatureInCommon(
            ICollection<Product> products, ICollection<Feature> features)
        {
            return products.Where(x => !x.Features.Intersect(features).Any());
        }

        public IEnumerable MergeCollectionsByProductName(
            ICollection<Product> products1, ICollection<Product> products2)
        {
            return products1.Concat(products2)
                .GroupBy(x => x.Name)
                .Select(x => new { Name = x.Key, Quantity = x.Sum(x => x.Quantity) });
        }

        public IEnumerable GetFamilyHighScore(ICollection<TestResults> results)
        {
            return results.GroupBy(x => x.FamilyId)
                .Select(x => x.Aggregate((i, j) => i.Score > j.Score ? i : j));
        }

        public IEnumerable<(string, int)> GetTopWords(string text, int topCount)
        {
            return new string(text.Where(c => !char.IsPunctuation(c)).ToArray())
                   .Split(" ")
                   .GroupBy(x => x.ToLower())
                   .Select(x => (x.Key, count: x.Count()))
                   .OrderByDescending(x => x.count)
                   .Take(topCount);
        }

        public bool IsValidSudokuBoard(int[][] board)
        {
            var digits = Enumerable.Range(1, 9);
            var lines = Enumerable.Range(0, 9).Select(line => Enumerable.Range(0, 9)
                                .Select(col => board[line][col]));
            var columns = Enumerable.Range(0, 9).Select(col => Enumerable.Range(0, 9)
                                .Select(line => board[line][col]));
            var boxes = Enumerable.Range(0, 3).SelectMany(x => Enumerable.Range(0, 3)
                                .Select(y => board.Skip(x * 3).Take(3)
                                .SelectMany(z => z.Skip(y * 3).Take(3))));
            return lines.Concat(columns).Concat(boxes)
                    .All(x => digits.Intersect(x).SequenceEqual(digits));
        }

        public double ReversedPolishCalculator(string[] expression)
        {
            return expression.Aggregate(Enumerable.Empty<double>(), (operands, current) =>
                        double.TryParse(current, out double parseResult)
                        ? operands.Append(parseResult)
                        : operands.SkipLast(2).Append(PerformOperation(operands.TakeLast(2), current)))
                   .Single();
        }

        private double PerformOperation(IEnumerable<double> operands, string operation)
        {
            var operand1 = operands.First();
            var operand2 = operands.Last();
            return operation switch
            {
                "+" => operand1 + operand2,
                "-" => operand1 - operand2,
                "*" => operand1 * operand2,
                "/" => operand1 / operand2,
                "^" => Math.Pow(operand1, operand2),
                _ =>throw new InvalidOperationException()
            };
        }
    }
}