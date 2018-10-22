using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //char result = FindTheDifference("abcde", "abcdev");
            //Console.WriteLine(result);
            //int[] results = ConstructRectangle(8);
            //Console.WriteLine(string.Format("{0},{1}", results[0], results[1]));
            //int result = CountDigitOne(1000);
            //Console.WriteLine(result);
            //bool result = IsPowerOfTwo(0);
            //Console.WriteLine(result);
            //int[] nums = new int[] { 1,1, 0, -1, 0, -2, 2 };
            //int[] nums = new int[] {-5, -4, -3, -2, -1, 0, 0, 1, 2, 3, 4, 5};
            //IList<IList<int>> result = FourSum(nums, 0);
            //foreach(IList a in result)
            //{
            //    foreach(int b in a)
            //    {
            //        Console.Write(b);
            //    }
            //    Console.WriteLine();
            //}
            //int[] num = new int[] {0,0,1,0 };
            //int result = ThreeSumClosest(num, 111);
            //ListNode l1 = buildNodeList(new int[] { 6,3,1,1,1, 2, 6,6,6,3,4,5,6 });
            //ListNode result = RemoveElements(l1, 6);
            //while (result != null) { Console.Write(result.val + "->");result = result.next; }
            //bool result = IsIsomorphic("ab", "aa");
            //Console.WriteLine(result);
            //ListNode l1 = buildNodeList(new int[] { 1, 2, 3, 4, 5 });
            //ListNode result = ReverseList(l1);
            //while (result != null) { Console.Write(result.val + "->"); }
            //int a = (1 << 8) - 1;
            //Console.WriteLine(a);
            //int result = CountNodes(buildTree());
            //int result = ComputeArea(-3, 0, 3, 4, 0, -1, 9, 2);
            //int result = ComputeArea(-2,-2,2,2,-2,-2,2,2);
            //Console.WriteLine(result);
            //TreeNode head = buildTree();
            //display(head);
            //TreeNode t = InvertTree(head);
            //Console.WriteLine();
            //display(t);
            //int a = Calculate("3+5 / 2 ");
            //Console.WriteLine(a);
            //IList<string> result = SummaryRanges(new int[] { 0,1,2,4,5,7,7 });
            //foreach (string s in result) Console.WriteLine(s);
            IList<int> result = MajorityElement(new int[] { 1,1,1,3,2,2,2 });
            foreach (int a in result) Console.WriteLine(a);
            Console.ReadLine();
        }

        static public IList<int> MajorityElement(int[] nums)
        {
            Array.Sort(nums);
            IList<int> result = new List<int>();
            for (int i = 0; i < nums.Length; )
            {
                int count = 0, start = nums[i];
                do
                {
                    count++; i++;
                }
                while (i < nums.Length && start == nums[i]);
                if (count > nums.Length / 3) result.Add(start);
            }
            return result;
        }

        static public IList<string> SummaryRanges(int[] nums)
        {
            IList<string> result = new List<string>();
            for (int i = 0; i < nums.Length;i++)
            {
                int start = nums[i];
                while (i + 1 < nums.Length && nums[i] + 1 == nums[i + 1]) i++;
                if (start != nums[i])
                {
                    result.Add(start + "->" + nums[i]);
                }
                else
                {
                    if (result.Count <= 0 || start.ToString() != result[result.Count - 1])
                    {
                        result.Add(start.ToString());
                    }
                }
            }

            return result;
        }
            static public int Calculate(string s)
        {
            string[] strs = s.Split(new char[] { ' ', '+', '-', '*', '/' }, StringSplitOptions.RemoveEmptyEntries);
            int[] nums = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++) nums[i] = int.Parse(strs[i]);
            char[] ops = new char[strs.Length - 1];
            Stack<int> results = new Stack<int>();
            int index = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if(s[i] == '+' || s[i] == '-' || s[i] == '*' || s[i] == '/')
                {
                    ops[index++] = s[i];
                }
            }

            results.Push(nums[0]);
            for(int i = 0; i < index; i++)
            {
                switch (ops[i])
                {
                    case '/': results.Push(results.Pop() / nums[i + 1]);break;
                    case '*': results.Push(results.Pop() * nums[i + 1]);break;
                    case '+':results.Push(nums[i + 1]);break;
                    case '-':results.Push(-nums[i + 1]);break;
                }
            }
            int result = 0;
            foreach (int r in results) result += r;
            return result;
        }

        static public void display(TreeNode t)
        {
            if (t == null) return;
            Console.WriteLine(t.val);
            display(t.left);
            display(t.right);
        }

        static public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;
            TreeNode t = root.left;
            root.left = InvertTree(root.right);
            root.right = InvertTree(t);
            return root;
        }

        static public int ComputeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            return (C - A) * (D - B) + (G - E) * (H - F) - countLength(A, C, E, G) * countLength(B, D, F, H)
;        }

        static public int countLength(int D1, int D2, int Da, int Db)
        {
            if (Db < D1 || D2 < Da) return 0;
            if (Da <= D1 && Db <= D2) return Db - D1;
            if (Da <= D1 && Db >= D2) return D2 - D1;
            if (Da >= D1 && Db <= D2) return Db - Da;
            if (Da >= D1 && Db >= D2) return D2 - Da;
            return 0;
        }

        static public TreeNode buildTree()
        {
            TreeNode head = new TreeNode(1), l1 = new TreeNode(2), l2 = new TreeNode(3),l3=new TreeNode(4),
                l4 = new TreeNode(5), l5 = new TreeNode(6), l6 = new TreeNode(9);
            head.left = l1;head.right = l2;
            l1.left = l3;l1.right = l4;l2.left = l5; l2.right = l6;
            return head;
        }


        static public int LeftHeight(TreeNode node)
        {
            int count = 0;
            TreeNode n = node;
            while (n != null)
            {
                count++;
                n = n.left;
            }
            return count;
        }

        static public int CountNodes(TreeNode root)
        {
            if (root == null) return 0;
            TreeNode node = root;
            int count = 0;
            int leftHeight = LeftHeight(node);
            while (node != null)
            {
                count++;
                int leftLH = leftHeight - 1;
                int rightLH = LeftHeight(node.right);
                if(leftLH == rightLH)
                {
                    count += (1 << leftLH) - 1;
                    node = node.right;
                    leftHeight = rightLH;
                }else
                {
                    count += (1 << rightLH) - 1;
                    node = node.left;
                    leftHeight = leftLH;
                }
            }
            return count;
        }


        static public int MaximalSquare(char[,] matrix)
        {
            if (matrix.Length == 0) return 0;
            int[,] db = new int[matrix.GetLength(0) + 1, matrix.GetLength(1) + 1];
            int result = 0;

            for(int i = 1; i <= matrix.GetLength(0); i++)
            {
                for(int j = 1; j <= matrix.GetLength(1); j++)
                {
                    if (matrix[i - 1, j - 1] == '1')
                    {
                        db[i, j] = Math.Min(Math.Min(db[i, j - 1], db[i - 1, j - 1]), db[i - 1, j]) + 1;
                        result = Math.Max(db[i, j], result);
                    }
                }
            }
            return result * result;
        }

        static public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums == null || nums.Length < 2 || k < 1 || t < 0) return false;

            var ss = new SortedSet<long>();
            for(int i = 0; i < nums.Length; i++)
            {
                if (i > k)
                {
                    ss.Remove(nums[i - k - 1]);
                }
                if (ss.GetViewBetween((long)nums[i] - t, (long)nums[i] + t).Count > 0)
                {
                    return true;
                }
                ss.Add(nums[i]);
            }
            return false;
        }

        static public bool CanFinish(int numCourses, int[,] prerequisites)
        {
            int[,] matrix = new int[numCourses, numCourses];
            int[] indegree = new int[numCourses];

            for(int i = 0; i < prerequisites.GetLength(0); i++)
            {
                int ready = prerequisites[i, 0];
                int pre = prerequisites[i, 1];
                if (matrix[pre, ready] == 0)
                {
                    indegree[ready]++;
                }
                matrix[pre, ready] = 1;
            }

            int count = 0;
            Queue<int> queue = new Queue<int>();
            for(int i = 0; i < indegree.Length; i++)
            {
                if (indegree[i] == 0) queue.Enqueue(i);
            }
            while (queue.Count != 0)
            {
                int course = queue.Dequeue();
                count++;
                for(int i = 0; i < numCourses; i++)
                {
                    if (matrix[course, i] != 0)
                    {
                        if(--indegree[i] == 0)
                        {
                            queue.Enqueue(i);
                        }
                    }
                }
            }
            return count == numCourses;
        }

        static public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null) return head;
            ListNode p = head, q = head.next, t = head;
            while (p.next != null)
            {
                if (q != null)
                {
                    p.next = q.next;
                    q.next = t;
                    t = q;
                    q = p.next;
                }
            }
            return t;
        }

        static public bool IsIsomorphic(string s, string t)
        {
            int[] map1 = new int[256], map2 = new int[256] ;
            for(int i = 0; i < s.Length; i++)
            {
                if (map1[s[i]] != map2[t[i]]) return false;
                map1[s[i]] = i+1;
                map2[t[i]] = i+1;
            }
            return true;
        }

        static public int CountPrimes(int n)
        {
            bool[] notPrime = new bool[n];
            int count = 0;
            for(int i = 2; i < n; i++)
            {
                if(notPrime[i] == false)
                {
                    count++;
                    for(int j = 2; i * j < n; j++)
                    {
                        notPrime[i * j] = true;
                    }
                }
            }
            return count;
        }

        static public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null) return null;
            head.next = RemoveElements(head.next, val);
            return head.val == val ? head.next : head;
        }

        static ListNode buildNodeList(int[] nums)
        {
            ListNode head = new ListNode(nums[0]), p = head;
            for(int i = 1; i < nums.Length; i++)
            {
                ListNode l = new ListNode(nums[i]);
                p.next = l;
                p = l;
            }
            return head;
        }

        static public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val <= l2.val)
            {
                l1.next = MergeTwoLists(l1.next, l2);
                return l1;
            }else
            {
                l2.next = MergeTwoLists(l1, l2.next);
                return l2;
            }
        }

        static public int ThreeSumClosest(int[] nums, int target)
        {
            int sum = 0, min = int.MaxValue, result = int.MaxValue;
            for(int i = 0; i < nums.Length - 2; i++)
            {
                for(int j = i + 1; j < nums.Length - 1; j++)
                {
                    for(int k = j + 1; k < nums.Length; k++)
                    {
                        sum = nums[i] + nums[j] + nums[k]-target;
                        min = Math.Min(min, Math.Abs(sum));
                        if (min == Math.Abs(sum)) result = sum;
                    }
                }
            }

            return result + target;
        }

        static public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<List<int>> result = new List<List<int>>();
            IList<string> compareString = new List<string>();
            Array.Sort(nums);
            for(int i = 0; i < nums.Length-3; i++)
            {
                for(int j = i + 1; j < nums.Length - 2; j++)
                {
                    for(int k = j + 1; k < nums.Length - 1; k++)
                    {
                        for(int q = k + 1; q < nums.Length; q++)
                        {
                            if (nums[i] + nums[j] + nums[k] + nums[q] == target)
                            {
                                if (!compareString.Contains(nums[i] + "," + nums[j] + "," + nums[k] + "," + nums[q]))
                                {
                                    result.Add(new List<int>() { nums[i], nums[j], nums[k], nums[q] });
                                    string str = nums[i] + "," + nums[j] + "," + nums[k] + "," + nums[q];
                                    compareString.Add(str);
                                }
                            }
                        }
                    }
                }
            }
            return result.ToArray();
        }

        static public bool IsPowerOfTwo(int n)
        {
            if (n <= 0) return false;
            if (n == 1 || n==2) return true;
            if (n % 2 == 0) return IsPowerOfTwo(n / 2);
            return false;
        }

        public int FirstUniqChar(string s)
        {
            int[] freq = new int[26];
            for(int i = 0; i < s.Length; i++)
            {
                freq[s[i] - 'a']++;
            }
            for (int i = 0; i < s.Length; i++)
                if (freq[s[i] - 'a'] == 1) return i;
            return -1;
        }

        public static int[] ConstructRectangle(int area)
        {
            int w = (int)Math.Floor(Math.Sqrt(area));
            while (area % w != 0) w--;
            return new int[] { area / w, w };
        }

        public int FindNthDigit(int n)
        {
            int length = 0;
            long mul = 1;
            long count = 0;
            int diff = 0;
            int base_num = 0;

            while (true)
            {
                long delta = (mul * 9) * (length + 1);
                count += delta;
                if (count > n) break;
                mul *= 10;
                length++;
                diff = n - (int)count;
            }

            if (length == 0) return n;
            base_num = (int)Math.Pow(10, length) - 1;
            base_num += (diff / (length + 1));
            int rem = diff % (length + 1);

            if (rem == 0)
                return base_num % 10;
            else
            {
                base_num += 1;
                rem = length - rem + 1;
                while (rem > 0)
                {
                    base_num /= 10;
                    rem--;
                }
                return base_num % 10;
            }
        }

        static public char FindTheDifference(string s, string t)
        {
            int c = 0;
            for (int i = 0; i < s.Length; i++) c ^= s[i];
            for (int i = 0; i < t.Length; i++) c ^= t[i];
            return (char)c;
        }

        //static public int NumRabbits(int[] answers)
        //{
             
        //}

        public int AddDigits(int num)
        {
            return (num - 1) % 9 + 1;
        }

        public int[] SingleNumber(int[] nums)
        {
            var set = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!set.Contains(nums[i]))
                    set.Add(nums[i]);
                else
                    set.Remove(nums[i]);
            }

            int[] res = new int[set.Count];

            int j = 0;
            foreach (int val in set)
            {
                res[j++] = val;
            }
            return res;
        }
        public bool IsUgly(int num)
        {
            if (num < 1)
                return false;
            var dList = new List<int> { 2, 3, 5 };
            while (num > 1)
            {
                var d = dList.FirstOrDefault(n => num % n == 0);
                if (d == 0)
                    return false;
                num /= d;
            }
            return num == 1;
        }

        public int NthUglyNumber(int n)
        {
            int[] ugArray = new int[n];
            ugArray[0] = 1;
            int twIn = 0, thrIn = 0, finIn = 0, curIn = 0;
            while (curIn < n - 1)
            {
                int two = 2 * ugArray[twIn];
                int thr = 3 * ugArray[thrIn];
                int fiv = 5 * ugArray[finIn];
                if (two <= thr && two <= fiv)
                {
                    if (two != ugArray[curIn])
                    {
                        curIn++;
                        ugArray[curIn] = two;
                    }
                    twIn++;
                }
                else if (thr <= two && thr <= fiv)
                {
                    if (thr != ugArray[curIn])
                    {
                        curIn++;
                        ugArray[curIn] = thr;
                    }
                    thrIn++;
                }
                else
                {
                    if (fiv != ugArray[curIn])
                    {
                        curIn++;
                        ugArray[curIn] = fiv;
                    }
                    finIn++;
                }
            }
            return ugArray[n - 1];
        }
        public int MissingNumber(int[] nums)
        {
            int sum = (nums.Length * (nums.Length + 1)) / 2;
            for (int i = 0; i < nums.Length; i++)
            {
                sum -= nums[i];
            }
            return sum;
            //int[] positions = new int[nums.Length + 1];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    positions[nums[i]] = 1;
            //}

            //int result = -1;
            //for (int i = 0; i < positions.Length; i++)
            //{
            //    if (positions[i] == 0)
            //        result = i;
            //}

            //return result;
        }

        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            string[] qualifiers = new string[] { "Billion", "Million", "Thousand", "" };
            int d = 1000000000;

            string s = "";
            int q = 0;
            while (num > 0)
            {
                int div = num / d;
                num = num % d;
                d /= 1000;
                if (div > 0) s += (s.Length > 0 ? " " : "") + NumToWords(div) + (q > 2 ? "" : " " + qualifiers[q]);
                q++;
            }

            return s;
        }

        public string NumToWords(int num)
        {
            string[] words = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
            string[] words2 = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            if (num < 20) return words[num - 1];
            if (num < 100) return words2[num / 10 - 2] + (num % 10 == 0 ? "" : " " + words[num % 10 - 1]);

            return words[num / 100 - 1] + " Hundred" + (num % 100 == 0 ? "" : " " + NumToWords(num % 100));
        }
        public IList<string> AddOperators(string num, int target)
        {
            var result = new List<string>();
            Helper(result, new StringBuilder(), num, target, 0, 0, 0);
            return result;
        }

        private void Helper(List<string> result, StringBuilder sb, string num, int target, int pos, long val, long carry)
        {
            if (pos == num.Length)
            {
                if (val == target)
                    result.Add(sb.ToString());
                return;
            }

            for (int i = 1; i + pos <= num.Length; i++)
            {
                if (num[pos] == '0' && i != 1)
                    break;
                long n = long.Parse(num.Substring(pos, i));
                int sbLength = sb.Length;
                if (sbLength == 0)
                {
                    sb.Append(n);
                    Helper(result, sb, num, target, pos + i, n, n);
                    sb.Length = sbLength;
                }
                else
                {
                    sb.Append("+" + n);
                    Helper(result, sb, num, target, pos + i, val + n, n);
                    sb.Length = sbLength;
                    sb.Append("-" + n);
                    Helper(result, sb, num, target, pos + i, val - n, -n);
                    sb.Length = sbLength;
                    sb.Append("*" + n);
                    Helper(result, sb, num, target, pos + i, val - carry + carry * n, carry * n);
                    sb.Length = sbLength;
                }
            }
        }
        public void MoveZeroes(int[] nums)
        {

            int zeroCount = 0;
            for (int oI = 0; oI < nums.Length; oI++)
            {
                if (nums[oI] == 0)
                {
                    zeroCount += 1;
                }
                else
                {
                    nums[oI - zeroCount] = nums[oI];
                }

            }

            if (zeroCount > 0)
            {
                int zeroStartIndex = nums.Length - zeroCount;

                for (int zI = 0; zI < zeroCount; zI++)
                {
                    nums[zeroStartIndex + zI] = 0;
                }
            }
        }


        public int NumSquares(int n)
        {

            if (n < 4) return n;
            int[] memo = new int[n + 1];
            for (int i = 0; i < 4; i++)
                memo[i] = i;
            for (int i = 4; i < n + 1; i++)
            {
                int j = 1;
                int minval = int.MaxValue;
                while (i - (j * j) >= 0)
                {
                    minval = Math.Min(minval, memo[i - (j * j)] + 1);
                    j++;
                }
                memo[i] = minval;
            }
            return memo[n];
        }

        public int HIndex2(int[] citations)
        {
            if (null == citations || citations.Length == 0) return 0;
            int left = 0;
            int right = citations.Length - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) / 2);
                if (citations[mid] == (citations.Length - mid))
                    return citations[mid];
                else if (citations[mid] > (citations.Length - mid))
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return citations.Length - (right + 1);
        }
        public int HIndex(int[] citations)
        {
            if (null == citations || citations.Length == 0) return 0;
            Array.Sort(citations);
            int hIndex = 0;
            for (int i = 0; i < citations.Length; i++)
            {
                if (citations[i] > citations.Length - i)
                    hIndex = Math.Max(citations.Length - i, hIndex);
                else
                    hIndex = Math.Max(citations[i], hIndex);
            }
            return hIndex;
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head == null || head.next == null) { return true; }
            ListNode last = null;
            return IsPalindrome(head, head.next.next, out last);
        }

        private bool IsPalindrome(ListNode slo, ListNode fst, out ListNode last)
        {
            if (fst != null && fst.next != null)
            {
                //if recursion returned false at any check then overall result is false   
                if (!IsPalindrome(slo.next, fst.next.next, out last)) { return false; }
            }
            else if (fst == null)
            {
                //for even length case
                last = slo.next;
            }
            else
            {
                //for odd  length case
                //fst.next == null
                last = slo.next.next;
            }

            if (slo.val == last.val) { last = last.next; return true; }
            //No need to update the last pointer in case of failed check because we skip remaining checks
            return false;
        }

        static int CountDigitOne(int n)
        {
            if (n <= 0) return 0;
            int q = n, x = 1, ans = 0;
            do
            {
                int digit = q % 10;
                q /= 10;
                ans += q * x;
                if (digit == 1) ans += n % x + 1;
                if (digit > 1) ans += x;
                x *= 10;
            } while (q > 0);
            return ans;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {

            Stack<TreeNode> stackp = getDFS(root, p, new Stack<TreeNode>());
            Stack<TreeNode> stackq = getDFS(root, q, new Stack<TreeNode>());

            while (stackp.Count != stackq.Count)
            {
                if (stackp.Count > stackq.Count)
                {
                    stackp.Pop();
                }
                if (stackq.Count > stackp.Count)
                {
                    stackq.Pop();
                }
            }

            if (stackp.Count > 0 && stackq.Count > 0)
            {
                while (stackp.Count > 0 && stackq.Count > 0)
                {
                    var tempp = stackp.Pop();
                    var tempq = stackq.Pop();

                    if (tempp.val == tempq.val)
                    {
                        return tempp;
                    }
                }
            }
            return null;
        }

        private Stack<TreeNode> getDFS(TreeNode root, TreeNode dest, Stack<TreeNode> stackPath)
        {

            if (root == null)
            {
                return stackPath;
            }

            if (root.val == dest.val)
            {
                stackPath.Push(dest);
                return stackPath;
            }

            if (root.left != null && root.val > dest.val)
            {
                stackPath.Push(root);
                stackPath = getDFS(root.left, dest, stackPath);
            }
            if (root.right != null && root.val < dest.val)
            {
                stackPath.Push(root);
                stackPath = getDFS(root.right, dest, stackPath);
            }
            return stackPath;
        }

        TreeNode answer = null;

        public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
        {
            DFS(root, p, q);
            return answer;
        }


        public int DFS(TreeNode root, TreeNode p, TreeNode q)
        {
            int count = 0;
            if (root != null)
            {
                if (root.val == p.val || root.val == q.val)
                {
                    count++;
                }

                if (count < 2)
                {
                    count += DFS(root.left, p, q);
                    count += DFS(root.right, p, q);
                }

                if (count == 2)
                {
                    count++;
                    answer = root;
                }
            }
            return count;
        }
        static ListNode head = new ListNode(0);
        static public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];
            int productOfLeftNumbers = 1;
            // set result[i] = product of all numbers from 0 to i-1
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = productOfLeftNumbers;
                productOfLeftNumbers = productOfLeftNumbers * nums[i];
            }
            int productOfRightNumbers = 1;
            //set result[i] = result[i] (i.e. product of all numbers from 0 to i-1) * product of all numbers from i+1 to nums.Length - 1
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] = result[i] * productOfRightNumbers;
                productOfRightNumbers = productOfRightNumbers * nums[i];
            }
            return result;
        }
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int N = nums.Length;
            Deque deque = new Deque();
            List<int> max = new List<int>();

            for (int i = 0; i < N; i++)
            {

                while (deque.Exists() && deque.PeekLast().Item1 <= nums[i])
                {
                    deque.GetLast();
                }

                deque.AddLast(new Tuple<int, int>(nums[i], i));

                while (deque.PeekFirst().Item2 < (i - k + 1))
                {
                    deque.GetFirst();
                }

                //deque.Debug();
                if (i + 1 >= k)
                {
                    max.Add(deque.PeekFirst().Item1);
                }
            }

            return max.ToArray(); ;
        }

        public bool SearchMatrix(int[,] matrix, int target)
        {
            if (matrix == null)
            {
                return false;
            }

            int r = matrix.GetUpperBound(0);
            int c = matrix.GetUpperBound(1);

            return SearchMatrix(matrix, target, 0, r, 0, c, r, c);
        }

        private bool SearchMatrix(int[,] matrix, int target, int r1, int r2, int c1, int c2, int R, int C)
        {
            if (r1 < 0 || r2 > R || c1 < 0 || c2 > C || r1 > r2 || c1 > c2)
            {
                return false;
            }
            if (r1 == r2 && c1 == c2)
            {
                return matrix[r1, c1] == target;
            }

            int r = r1 + (r2 - r1) / 2;
            int c = c1 + (c2 - c1) / 2;

            if (matrix[r, c] == target)
            {
                return true;
            }

            bool b;
            if (matrix[r, c] > target)
            {
                b = SearchMatrix(matrix, target, r1, r, c1, c, R, C);
                if (b) return b;
            }
            if (matrix[r, c] < target)
            {
                b = SearchMatrix(matrix, target, r + 1, r2, c + 1, c2, R, C);
                if (b) return b;
            }

            b = SearchMatrix(matrix, target, r + 1, r2, c1, c, R, C);
            if (b) return b;

            b = SearchMatrix(matrix, target, r1, r, c + 1, c2, R, C);
            if (b) return b;

            return false;
        }


        Dictionary<char, Func<int, int, int>> operations = new Dictionary<char, Func<int, int, int>>
            {
                {'*', (a, b) =>{ return (a * b); } },
                {'-', (a, b) =>{ return (a - b); } },
                {'+', (a, b) =>{ return (a + b); } },
            };
        public IList<int> DiffWaysToCompute(string input)
        {
            if (input.Length > 0 && !operations.Keys.Intersect(input).Any())
            {
                return new List<int> { int.Parse(input) };
            }
            if (input.Length == 0)
            {
                return new List<int> { 1 };
            }

            List<int> res = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (operations.ContainsKey(input[i]))
                {
                    foreach (var resLeft in DiffWaysToCompute(input.Substring(0, i)))
                    {
                        foreach (var resRight in DiffWaysToCompute(input.Substring(i + 1, input.Length - i - 1)))
                        {
                            res.Add(operations[input[i]](resLeft, resRight));
                        }
                    }
                }
            }
            return res;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {

            // MinHeap
            var minHeap = new MinHeap(lists.Length);
            minHeap.InitializeHeap(lists);

            ListNode resultNode = null;
            ListNode prev = null;

            while (minHeap.Any())
            {
                var top = minHeap.RemoveTop();
                if (resultNode == null)
                {
                    prev = top;
                    resultNode = prev;
                }
                else
                {
                    prev.next = top;
                    prev = top;
                }
                minHeap.Add(top.next);
            }

            return resultNode;

            /*
            // Divide and Conquer approach
            if (!lists.Any()) {
                return null;
            }

            if (lists.Length == 1) {
                return lists[0];
            }

            return MergeKLists(lists, 0, lists.Length - 1);*/
        }

        private class MinHeap
        {
            ListNode[] heapds;

            bool isEmpty = true;
            int currentIndex = -1;

            public MinHeap(int k)
            {
                heapds = new ListNode[k];
            }

            public void InitializeHeap(ListNode[] lists)
            {
                foreach (var l in lists)
                {
                    Add(l);
                }
            }

            public ListNode RemoveTop()
            {
                if (currentIndex < 0)
                {
                    return null;
                }
                var nodeToReturn = heapds[0];
                swap(0, currentIndex);
                heapds[currentIndex--] = null;

                MinHeapifyRoot(0);
                return nodeToReturn;
            }

            private void MinHeapifyRoot(int index)
            {
                if (index > currentIndex)
                {
                    return;
                }

                var left = 2 * index + 1;
                var right = 2 * index + 2;

                var minIndex = index;
                if (left <= currentIndex)
                {
                    if (heapds[left].val < heapds[minIndex].val)
                    {
                        minIndex = left;
                    }
                }

                if (right <= currentIndex)
                {
                    if (heapds[right].val < heapds[minIndex].val)
                    {
                        minIndex = right;
                    }
                }

                if (minIndex != index)
                {
                    swap(minIndex, index);
                    MinHeapifyRoot(minIndex);
                }

            }

            public void Add(ListNode x)
            {
                if (x == null)
                {
                    return;
                }
                heapds[++currentIndex] = x;
                HeapifyLeaf(currentIndex);
            }

            private void HeapifyLeaf(int index)
            {
                if (index == 0)
                {
                    return;
                }

                var parentIndex = index % 2 == 0 ? index / 2 - 1 : index / 2;

                if (heapds[parentIndex].val > heapds[index].val)
                {
                    swap(parentIndex, index);
                    HeapifyLeaf(parentIndex);
                }
            }

            private void swap(int x, int y)
            {
                var temp = heapds[x];
                heapds[x] = heapds[y];
                heapds[y] = temp;
            }

            public bool Any()
            {
                return currentIndex >= 0;
            }

            public void Print()
            {
                foreach (var l in heapds)
                {
                    Console.WriteLine(l.val);
                }
            }
        }

        private ListNode MergeKLists(ListNode[] lists, int start, int end)
        {
            if (end == start)
            {
                return lists[start];
            }
            if (end - start == 1)
            {
                var mergedHeadNode = MergeTwoNodes(lists[start], lists[end]);
                return mergedHeadNode;
            }

            var mid = start + (end - start) / 2;

            var leftMergedNode = MergeKLists(lists, start, mid);
            var rightMergedNode = MergeKLists(lists, mid + 1, end);

            return MergeTwoNodes(leftMergedNode, rightMergedNode);
        }

        private ListNode MergeTwoNodes(ListNode left, ListNode right)
        {
            // Iterative solution

            ListNode prev = null;
            ListNode head = prev;

            while (left != null && right != null)
            {
                if (left.val <= right.val)
                {
                    if (prev == null)
                    {
                        head = left;
                    }
                    else
                    {
                        prev.next = left;
                    }
                    prev = left;
                    left = left.next;
                }
                else
                {
                    if (prev == null)
                    {
                        head = right;
                    }
                    else
                    {
                        prev.next = right;
                    }

                    prev = right;
                    right = right.next;
                }
            }
            if (left == null)
            {
                if (prev == null)
                {
                    return right;
                }
                prev.next = right;
            }

            if (right == null)
            {
                if (prev == null)
                {
                    return left;
                }
                prev.next = left;
            }

            return head;

            /*
            // Recursive solution
            if (left == null) {
                return right;
            }

            if (right == null) {
                return left;
            }

            if (left.val <= right.val) {
                left.next = MergeTwoNodes(left.next, right);
                return left;
            }

            right.next = MergeTwoNodes(left, right.next);
            return right;*/
        }

        public String SmallestGoodBase(String n)
        {
            long num = 0;
            long.TryParse(n, out num);

            for (int m = (int)(Math.Log(num + 1) / Math.Log(2)); m > 2; m--)
            {
                long l = (long)(Math.Pow(num + 1, 1.0 / m));
                long r = (long)(Math.Pow(num, 1.0 / (m - 1)));

                while (l <= r)
                {
                    long k = l + ((r - l) >> 1);
                    long f = 0L;
                    for (int i = 0; i < m; i++, f = f * k + 1) ;

                    if (num == f)
                    {
                        return k.ToString();
                    }
                    else if (num < f)
                    {
                        r = k - 1;
                    }
                    else
                    {
                        l = k + 1;
                    }
                }
            }

            return (num - 1).ToString();
        }

        int MAXCOUNT = 6;   // the max balls you need will not exceed 6 since "The number of balls in your hand won't exceed 5"

        public int FindMinStep(String board, String hand)
        {
            int[] handCount = new int[26];
            for (int i = 0; i < hand.Length; ++i) ++handCount[hand[i] - 'A'];
            int rs = helper(board + "#", handCount);  // append a "#" to avoid special process while j==board.length, make the code shorter.
            return rs == MAXCOUNT ? -1 : rs;
        }
        private int helper(String s, int[] h)
        {
            s = removeConsecutive(s);
            if (s.Equals("#")) return 0;
            int rs = MAXCOUNT, need = 0;
            for (int i = 0, j = 0; j < s.Length; ++j)
            {
                if (s[j] == s[i]) continue;
                need = 3 - (j - i);     //balls need to remove current consecutive balls.
                if (h[s[i] - 'A'] >= need)
                {
                    h[s[i] - 'A'] -= need;
                    rs = Math.Min(rs, need + helper(s.Substring(0, i) + s.Substring(j), h));
                    h[s[i] - 'A'] += need;
                }
                i = j;
            }
            return rs;
        }
        //remove consecutive balls longer than 3
        private String removeConsecutive(String board)
        {
            for (int i = 0, j = 0; j < board.Length; ++j)
            {
                if (board[j] == board[i]) continue;
                if (j - i >= 3) return removeConsecutive(board.Substring(0, i) + board.Substring(j));
                else i = j;
            }
            return board;
        }


        public int ReversePairs(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;
            return mergeSort(nums, 0, nums.Length - 1);
        }
        private int mergeSort(int[] nums, int l, int r)
        {
            if (l >= r) return 0;
            int mid = l + (r - l) / 2;
            int count = mergeSort(nums, l, mid) + mergeSort(nums, mid + 1, r);
            int[] cache = new int[r - l + 1];
            int i = l, t = l, c = 0;
            for (int j = mid + 1; j <= r; j++, c++)
            {
                while (i <= mid && nums[i] <= 2 * (long)nums[j]) i++;
                while (t <= mid && nums[t] < nums[j]) cache[c++] = nums[t++];
                cache[c] = nums[j];
                count += mid - i + 1;
            }
            while (t <= mid) cache[c++] = nums[t++];
            System.Array.Copy(cache, 0, nums, l, r - l + 1);
            return count;
        }
        public int FindMaximizedCapital(int k, int W, int[] Profits, int[] Capital)
        {
            int n = Profits.Length;

            IList<Project> projects = new List<Project>();

            for (int i = 0; i < n; i++)
            {
                projects.Add(new Project() { capital = Capital[i], profit = Profits[i] });
            }

            LinkedList<Project> orderedProjects = new LinkedList<Project>(projects.OrderByDescending(p => p.profit).ThenBy(p => p.capital));

            int totalCapital = W;

            for (int i = 0; i < k; i++)
            {
                totalCapital += GetBiggestReturn(totalCapital, orderedProjects);
            }

            return totalCapital;

        }

        int GetBiggestReturn(int availableCapital, LinkedList<Project> projects)
        {
            foreach (var project in projects)
            {
                if (project.capital <= availableCapital)
                {
                    projects.Remove(project); // O(1) cost   
                    return project.profit;
                }
            }
            return 0;
        }


        public int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            int m = nums1.Length;
            int n = nums2.Length;
            int[] r = new int[k];

            for (int k1 = 0; k1 <= k && k1 <= m; k1++)
            {
                int k2 = k - k1;
                if (k2 > n) continue;
                int[] d1 = GetMax(nums1, k1);
                int[] d2 = GetMax(nums2, k2);
                int[] d = Merge(d1, d2, k);

                // Console.WriteLine("k1={0},d1=[{1}],k2={2},d2=[{3}],d=[{4}]", k1, PrintArray(d1), k2, PrintArray(d2), PrintArray(d));
                if (GreaterThan(d, 0, r, 0)) r = d;
            }

            return r;
        }

        public string PrintArray(int[] d)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int dg in d)
            {
                if (sb.Length > 0) sb.Append(",");
                sb.Append(dg);
            }

            return sb.ToString();
        }

        public int[] GetMax(int[] nums, int k)
        {
            int[] d = new int[k];
            int s = 0, n = nums.Length;
            for (int i = 0; i < k; i++)
            {
                int e = n - k + i;
                if (e < 0 || s >= n) continue;
                int md = s;
                for (int j = md + 1; j <= e; j++)
                {
                    if (nums[j] > nums[md]) md = j;
                }

                // Console.WriteLine("nums.Length={0}, md={1}", nums.Length, md);
                d[i] = nums[md];
                s = md + 1;
            }

            return d;
        }

        public bool GreaterThan(int[] d1, int i1, int[] d2, int i2)
        {
            int m = d1.Length;
            int n = d2.Length;
            int i = 0, j = 0;

            for (i = i1, j = i2; i < m && j < n && d1[i] == d2[j]; i++, j++) ;

            if (j >= n) return true;
            if (i >= m) return false;
            if (d1[i] > d2[j]) return true;
            return false;
        }

        public int[] Merge(int[] d1, int[] d2, int k)
        {
            int m = d1.Length;
            int n = d2.Length;
            int i1 = 0, i2 = 0;
            int[] d = new int[k];

            for (int i = 0; i < k; i++)
            {
                d[i] = GreaterThan(d1, i1, d2, i2) ? d1[i1++] : d2[i2++];
            }

            return d;
        }

        public int FindRotateSteps(String ring, String key)
        {
            int n = ring.Length;
            int m = key.Length;
            int[,] dp = new int[m + 1, n];

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    dp[i, j] = int.MaxValue;
                    for (int k = 0; k < n; k++)
                    {
                        if (ring[k] == key[i])
                        {
                            int diff = Math.Abs(j - k);
                            int step = Math.Min(diff, n - diff);
                            dp[i, j] = Math.Min(dp[i, j], step + dp[i + 1, k]);
                        }
                    }
                }
            }

            return dp[0, 0] + m;
        }

        public int CountRangeSum(int[] nums, int lower, int upper)
        {
            int cnt = 0;
            if (nums.Length > 0)
            {
                MultiSet rSet = new MultiSet();
                rSet.Add(0);
                long sum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += (long)nums[i];
                    cnt += rSet.Distance(sum - (long)upper, sum - (long)lower);
                    rSet.Add(sum);
                }
            }
            return cnt;
        }
        private Dictionary<Tuple<int, int>, int> positionAndLongestIncreasingCount = new Dictionary<Tuple<int, int>, int>();
        private Tuple<int, int>[] directions = new Tuple<int, int>[] { Tuple.Create(0, 1), Tuple.Create(0, -1), Tuple.Create(-1, 0), Tuple.Create(1, 0) };
        public int LongestIncreasingPath(int[,] matrix)
        {
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);

            var global = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    var local = DFS(matrix, i, j, long.MinValue);

                    global = Math.Max(global, local);
                }
            }

            return global;
        }

        private int DFS(int[,] matrix, int x, int y, long preValue)
        {
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);

            if (x < 0 || x >= row || y < 0 || y >= col) return 0;
            if (matrix[x, y] <= preValue) return 0;

            var curPosition = Tuple.Create(x, y);

            if (positionAndLongestIncreasingCount.ContainsKey(curPosition))
                return positionAndLongestIncreasingCount[curPosition];

            var global = 0;
            foreach (var direction in directions)
            {
                var nextX = x + direction.Item1;
                var nextY = y + direction.Item2;

                var local = DFS(matrix, nextX, nextY, matrix[x, y]);

                global = Math.Max(global, local);
            }

            global += 1;

            positionAndLongestIncreasingCount[curPosition] = global;

            return global;
        }

        public static int minPatches(int[] nums, int n)
        {
            long max = 0;
            int cnt = 0;
            for (int i = 0; max < n;)
            {
                if (i >= nums.Length || max < nums[i] - 1)
                {
                    max += max + 1;
                    cnt++;
                }
                else
                {
                    max += nums[i];
                    i++;
                }
            }
            return cnt;
        }

        public bool isSelfCrossing(int[] x)
        {
            if (x.Length <= 3)
            {
                return false;
            }
            int i = 2;
            // keep spiraling outward
            while (i < x.Length && x[i] > x[i - 2])
            {
                i++;
            }
            if (i >= x.Length)
            {
                return false;
            }
            // transition from spiraling outward to spiraling inward
            if ((i >= 4 && x[i] >= x[i - 2] - x[i - 4]) ||
                    (i == 3 && x[i] == x[i - 2]))
            {
                x[i - 1] -= x[i - 3];
            }
            i++;
            // keep spiraling inward
            while (i < x.Length)
            {
                if (x[i] >= x[i - 2])
                {
                    return true;
                }
                i++;
            }
            return false;
        }

        public IList<IList<int>> PalindromePairs(string[] words)
        {
            IList<IList<int>> list = new List<IList<int>>();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = words[i].Length - 1; j >= 0; j--)
                {
                    sb.Append(words[i][j]);
                }
                dict.Add(sb.ToString(), i);
            }

            for (int i = 0; i < words.Length; i++)
            {
                string str = words[i];
                for (int j = 0; j < str.Length; j++)
                {
                    string sub1 = str.Substring(j);
                    string sub2 = str.Substring(0, j);
                    if (IsPalin(sub1) && dict.ContainsKey(sub2) && dict[sub2] != i)
                    {
                        list.Add(new List<int> { i, dict[sub2] });
                        if (sub2 == "")
                        {
                            list.Add(new List<int> { dict[sub2], i });
                        }
                    }
                    if (IsPalin(sub2) && dict.ContainsKey(sub1) && dict[sub1] != i)
                    {
                        list.Add(new List<int> { dict[sub1], i });
                    }

                }
            }

            return list;
        }

        private bool IsPalin(string str)
        {
            for (int i = 0; i < str.Length / 2; ++i)
            {
                if (str[i] != str[str.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }

        //public int MaxEnvelopes(int[,] envelopes)
        //{
        //    //IComparer c = new ReverseComparer();

        //    Array.Sort(envelopes, (x,y)=> { x[0] - y[0]; });
        //    int m = envelopes.Length;
        //    int[] dp = new int[m];
        //    int len = 0;
        //    for (int i = 0; i < m; i++)
        //    {
        //        int insert = Array.BinarySearch(dp, 0, len, envelopes[i,1]);
        //        if (insert < 0) insert = -(insert + 1);
        //        if (insert == len) len++;
        //        dp[insert] = envelopes[i,1];
        //    }
        //    return len;

        //}

        public int MaxSumSubmatrix(int[,] matrix, int k)
        {
            int liRow = matrix.GetLength(0);
            int liCol = matrix.GetLength(1);

            int[,] liaTotal = new int[liRow, liCol];
            int[] liaSum = new int[liRow];

            int liResult = int.MinValue;

            for (int i = 0; i < liRow; ++i)
            {
                liaTotal[i, 0] = matrix[i, 0];
                for (int j = 1; j < liCol; ++j)
                {
                    liaTotal[i, j] += liaTotal[i, j - 1] + matrix[i, j];
                }
            }

            for (int i = 0; i < liCol; ++i)
            {
                for (int j = -1; j < i; ++j)
                {
                    for (int m = 0; m < liRow; ++m)
                    {
                        liaSum[m] = liaTotal[m, i] - (j == -1 ? 0 : liaTotal[m, j]) + (m == 0 ? 0 : liaSum[m - 1]);
                    }

                    for (int m = 0; m < liRow; ++m)
                    {
                        for (int n = -1; n < m; ++n)
                        {
                            int liValue = liaSum[m] - (n == -1 ? 0 : liaSum[n]);
                            if (liValue == k)
                                return k;
                            if (liValue <= k)
                                liResult = Math.Max(liResult, liValue);
                        }
                    }

                }
            }
            return liResult;
        }

        public bool IsRectangleCover2(int[,] rectangles)
        {
            bool RectangleCover = true;
            Hashtable coordinate = new Hashtable();
            int[] max = new int[] { rectangles[0, 0], rectangles[0, 1], rectangles[0, 2], rectangles[0, 3] };
            for (int i = 0; i < rectangles.GetLength(0); i++)
            {
                for (int j = rectangles[i, 0]; j < rectangles[i, 2]; j++)
                {
                    for (int k = rectangles[i, 1]; k < rectangles[i, 3]; k++)
                    {
                        if (coordinate.Contains(j.ToString() + k.ToString()))
                        {
                            return false;
                        }
                        coordinate.Add(j.ToString() + k.ToString(), "");
                    }
                }

                max[0] = rectangles[i, 0] < max[0] ? rectangles[i, 0] : max[0];
                max[1] = rectangles[i, 1] < max[1] ? rectangles[i, 1] : max[1];
                max[2] = rectangles[i, 2] > max[2] ? rectangles[i, 2] : max[2];
                max[3] = rectangles[i, 3] > max[3] ? rectangles[i, 3] : max[3];
            }
            if (coordinate.Count != ((max[2] - max[0]) * (max[3] - max[1])))
            {
                RectangleCover = false;
            }
            return RectangleCover;
        }

        public bool IsRectangleCover1(int[,] rectangles)
        {
            bool RectangleCover = true;
            Hashtable coordinate = new Hashtable();
            int[] max = new int[] { rectangles[0, 0], rectangles[0, 1], rectangles[0, 2], rectangles[0, 3] };
            for (int i = 0; i < rectangles.GetLength(0); i++)
            {
                for (int j = rectangles[i, 0]; j < rectangles[i, 2]; j++)
                {
                    for (int k = rectangles[i, 1]; k < rectangles[i, 3]; k++)
                    {
                        if (coordinate.Contains(j.ToString() + k.ToString()))
                        {
                            return false;
                        }
                        coordinate.Add(j.ToString() + k.ToString(), "");
                    }
                }

                max[0] = rectangles[i, 0] < max[0] ? rectangles[i, 0] : max[0];
                max[1] = rectangles[i, 1] < max[1] ? rectangles[i, 1] : max[1];
                max[2] = rectangles[i, 2] > max[2] ? rectangles[i, 2] : max[2];
                max[3] = rectangles[i, 3] > max[3] ? rectangles[i, 3] : max[3];
            }
            if (coordinate.Count != ((max[2] - max[0]) * (max[3] - max[1])))
            {
                RectangleCover = false;
            }
            return RectangleCover;
        }

        public bool IsRectangleCover(int[,] rectangles)
        {

            if (rectangles.Length == 0) return false;

            int x1 = int.MaxValue;
            int x2 = int.MinValue;
            int y1 = int.MaxValue;
            int y2 = int.MinValue;

            HashSet<String> set = new HashSet<String>();
            int area = 0;

            for (int i =0;i<rectangles.Length;i++)
            {
                x1 = Math.Min(rectangles[i,0], x1);
                y1 = Math.Min(rectangles[i,1], y1);
                x2 = Math.Max(rectangles[i,2], x2);
                y2 = Math.Max(rectangles[i,3], y2);

                area += (rectangles[i,2] - rectangles[i,0]) * (rectangles[i,3] - rectangles[i,1]);

                String s1 = rectangles[i,0] + " " + rectangles[i,1];
                String s2 = rectangles[i,0] + " " + rectangles[i,3];
                String s3 = rectangles[i,2] + " " + rectangles[i,3];
                String s4 = rectangles[i,2] + " " + rectangles[i,1];

                if (!set.Add(s1)) set.Remove(s1);
                if (!set.Add(s2)) set.Remove(s2);
                if (!set.Add(s3)) set.Remove(s3);
                if (!set.Add(s4)) set.Remove(s4);
            }

            if (!set.Contains(x1 + " " + y1) || !set.Contains(x1 + " " + y2) || !set.Contains(x2 + " " + y1) || !set.Contains(x2 + " " + y2) || set.Count != 4) return false;

            return area == (x2 - x1) * (y2 - y1);
        }
        public int[,] directions1 = new int[,] { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        public int TrapRainWater(int[,] heightMap)
        {
            var total = 0;
            var m = heightMap.GetLength(0);
            var n = heightMap.GetLength(1);
            var visitied = new bool[m, n];
            var q = new BinaryHeap<int[]>((a, b) => a[2] - b[2]);
            for (var i = 0; i < m; ++i)
            {
                q.Enqueue(new int[] { i, 0, heightMap[i, 0] });
                q.Enqueue(new int[] { i, n - 1, heightMap[i, n - 1] });
                visitied[i, 0] = visitied[i, n - 1] = true;// don't forget to set visited when init the queue
            }

            for (var i = 0; i < n; ++i)
            {
                q.Enqueue(new int[] { 0, i, heightMap[0, i] });
                q.Enqueue(new int[] { m - 1, i, heightMap[m - 1, i] });
                visitied[0, i] = visitied[m - 1, i] = true;
            }

            while (q.Count > 0)
            {
                var cell = q.Dequeue();
                for (var i = 0; i < 4; ++i)
                {
                    var x = cell[0] + directions1[i, 0];
                    var y = cell[1] + directions1[i, 1];
                    if (x < 0 || x == m || y < 0 || y == n || visitied[x, y]) continue;
                    total += Math.Max(0, cell[2] - heightMap[x, y]);
                    q.Enqueue(new int[] { x, y, Math.Max(cell[2], heightMap[x, y]) });
                    visitied[x, y] = true;
                }
            }

            return total;
        }

        public class BinaryHeap<T>
        {
            List<T> list = new List<T>();
            private Comparison<T> comparison;
            public BinaryHeap(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }

            public int Count
            {
                get
                {
                    return list.Count;
                }
            }

            public T Dequeue()
            {
                var item = list[0];
                list.RemoveAt(0);
                return item;
            }

            public void Enqueue(T item)
            {
                if (list.Count == 0)
                {
                    list.Add(item);
                }
                else
                {
                    var i = list.BinarySearch(item, Comparer<T>.Create(comparison));
                    i = i >= 0 ? i : ~i;
                    if (list.Count == i)
                    {
                        list.Add(item);
                    }
                    else
                    {
                        list.Insert(i, item);
                    }
                }
            }

            public T Seek()
            {
                return list[0];
            }
        }

    }


    public class ReverseComparer : IComparer<int[]>
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        public int Compare(int[] x, int[] y)
        {
            return x[0]-y[0];
        }
    }



    class MultiSet
    {
        public List<long> list;
        public MultiSet() { list = new List<long>(); }
        public void Add(long i)
        {
            if (list.Count == 0) list.Add(i);
            else
            {
                int u = Upper(i);
                if (u < 0) u = 0;
                if (u == list.Count) list.Add(i);
                else list.Insert(u, i);
            }
        }
        public int Lower(long o)
        {
            int lo = 0, hi = list.Count - 1;
            if (o.CompareTo(list[lo]) < 0) return lo - 1;
            else if (o.CompareTo(list[hi]) > 0) return hi + 1;
            else
            {
                while (lo <= hi)
                {
                    int m = (hi - lo) / 2 + lo;
                    if (list[m].CompareTo(o) == 0 && (m == 0 || list[m - 1].CompareTo(o) < 0)) return m;
                    else if (list[m].CompareTo(o) < 0) lo = m + 1;
                    else hi = m - 1;
                }
                return lo;
            }
        }
        public int Upper(long o)
        {
            int lo = 0, hi = list.Count - 1;
            if (o.CompareTo(list[lo]) < 0) return lo - 1;
            else if (o.CompareTo(list[hi]) >= 0) return hi + 1;
            else
            {
                while (lo <= hi)
                {
                    int m = (hi - lo) / 2 + lo;
                    if (list[m].CompareTo(o) == 0 && (m == list.Count - 1 || list[m + 1].CompareTo(o) > 0)) return m;
                    else if (list[m].CompareTo(o) > 0) hi = m - 1;
                    else lo = m + 1;
                }
                return lo;
            }
        }
        public int Distance(long lo, long up)
        {
            int l = Lower(lo);
            int u = Upper(up);
            int dis = 0;
            //Console.Write("lo="+lo+" up="+up+" [");
            if (u >= l)
            {
                if (u == l)
                {
                    if (u >= 0 && u < list.Count && list[u] <= up && list[l] >= lo) dis = 1;
                }
                else
                {
                    if (u < list.Count && list[u] == up) u++;
                    if (l < 0) l = 0;
                    else if (list[l] < lo) l++;

                    dis = u - l;
                }
            }
            /*
            Console.Write("dis="+dis+" lo="+lo+" up="+up+" [");
            foreach(long ll in list) Console.Write(ll+" ");
            Console.WriteLine("] l="+l+" u="+u);
            */
            return dis;
        }

        public bool CanCross(int[] stones)
        {
            return CanCrossDp_nSquare_improved(stones);
        }
        // faster than 76% of c# submissions
        public bool CanCrossDp_nSquare_improved(int[] stones)
        {
            if (stones == null) return false;
            if (stones.Length < 3) return stones[1] == 1;
            var len = stones.Length;
            var dp = new Dictionary<int, HashSet<int>>();

            if (stones[1] != 1) return false;
            foreach (var s in stones)
                dp.Add(s, new HashSet<int>());
            dp[1].Add(1);

            for (int i = 1; i < len; i++)
            {
                var row = stones[i];
                var jumps = dp[row].ToList();

                foreach (var j in jumps)
                {
                    if (dp.ContainsKey(row + j))
                        dp[row + j].Add(j);
                    if (row + j - 1 != 0 && dp.ContainsKey(row + j - 1))
                        dp[row + j - 1].Add(j - 1);
                    if (dp.ContainsKey(row + j + 1))
                        dp[row + j + 1].Add(j + 1);
                }
            }

            return dp[stones[len - 1]].Any();
        }
        public bool CanCrossDp_nSquare(int[] stones)
        {
            if (stones == null) return false;
            if (stones.Length < 3) return stones[1] == 1;
            var len = stones.Length;
            var dp = new Dictionary<int, HashSet<int>>();

            if (stones[1] != 1) return false;
            foreach (var s in stones)
                dp.Add(s, new HashSet<int>());
            dp[1].Add(1);

            for (int i = 1; i < len; i++)
            {
                var row = stones[i];
                var jumps = dp[stones[i]];
                for (int j = i + 1; j < len; j++)
                {
                    var distance = stones[j] - row;
                    // if current rows previous jumps 
                    if (jumps.Contains(distance) ||   //a previous jump == distance
                       jumps.Contains(distance - 1) ||  // prev jump +1 == distance
                       jumps.Contains(distance + 1))   // prev jump - 1 == distance
                        dp[stones[j]].Add(distance);  // there is a way to jump distance to get from i to j stone base on prev jumps   
                }
                if (dp[stones[len - 1]].Any()) return true;
            }

            return false;
        }

        public bool CanCrossDp_nCube(int[] stones)
        {
            if (stones == null) return false;
            if (stones.Length < 3) return stones[1] == 1;
            var len = stones.Length;
            var dp = new int[len, len];

            if (stones[1] != 1) return false;
            dp[0, 1] = 1;

            for (int i = 1; i < len; i++)
            {
                var row = stones[i];
                for (int j = i + 1; j < len; j++)
                {
                    var distance = stones[j] - row;
                    for (int k = i - 1; k >= 0; k--)
                    {
                        var prevJump = dp[k, i];
                        if (prevJump == 0) continue;
                        var diff = distance - prevJump;
                        if (diff >= -1 && diff <= 1)
                            dp[i, j] = prevJump + diff;
                    }

                }
                if (dp[i, len - 1] > 0) return true;
            }

            return false;
        }

        // O(3^n)
        public bool CanCrossRec(int[] stones, int i, int pos, int prevJump)
        {

            while (i < stones.Length && stones[i] < pos)
                i++;
            if (i >= stones.Length) return false;
            if (stones[i] != pos) return false;
            if (i == stones.Length - 1) return true;

            return CanCrossRec(stones, i + 1, pos + prevJump, prevJump)
                || CanCrossRec(stones, i + 1, pos + prevJump - 1, prevJump - 1)
                || CanCrossRec(stones, i + 1, pos + prevJump + 1, prevJump + 1);
        }

        public int SplitArray(int[] nums, int m)
        {
            int n = nums.Length;
            long[,] dp = new long[m + 1, n];

            long s = 0;
            for (int i = 0; i < n; i++)
            {
                s += (long)nums[i];
                dp[1, i] = s;
            }

            for (int i = 2; i <= m; i++)
            {
                for (int j = i - 1; j < n; j++)
                {
                    dp[i, j] = dp[1, j];
                    for (int k = i - 2; k < j; k++)
                    {
                        dp[i, j] = Math.Min(dp[i, j], Math.Max(dp[i - 1, k], dp[1, j] - dp[1, k]));
                    }
                }
            }

            return (int)dp[m, n - 1];
        }

        public int FindKthNumber(int n, int k)
        {
            if (n < 10) return k;

            int ret = 0;
            //10 buckets, 9 buckets are used on the first pass as there is no "0" bucket initially.
            int[] buckets = new int[10]; 
            bool isFirst = true;

            while (k > 0)
            {
                //obtain the count of digits in each bucket.
                GenerateBuckets(n, buckets, isFirst);

                //determine which bucket k lies in, this index is the next digit of the return value.
                int bucketIndex = FindIndex(k, buckets);
                ret = ret * 10 + bucketIndex + (isFirst ? 1 : 0); //add the next digit

                //k and n need to be modified for the next round.
                k -= (ElementsBefore(bucketIndex, buckets) + 1);
                n = buckets[bucketIndex] - 1;
                isFirst = false;
            }
            return ret;
        }

        private static void GenerateBuckets(int n, int[] buckets, bool isFirst)
        {
            int iterations = isFirst ? 9 : 10;

            int maxValue = ObtainMaxBucketSize(n); //the max value in a bucket is a repetition of 1's (for example, 111)
            int minValue = maxValue - (int)Math.Pow(10, (int)Math.Log10(n)); //the min value of a bucket is the maxValue with 1 less 1 (example: 11).
            //Note: the minValue may be 0.

            for (int i = 0; i < iterations; i++)
                buckets[i] = minValue;

            int remaining = n - minValue * iterations; //we have handled minValue * iterations elements, determine how many are left.
            int maxAddition = maxValue - minValue; //A power of 10, the most we can add to a single bucket.

            for (int i = 0; i < iterations; i++)
            {
                buckets[i] += Math.Max(0, Math.Min(remaining, maxAddition));
                remaining -= maxAddition;
                if (remaining <= 0) break;
            }
        }

        /// <summary>The number of elements before the given bucket index.</summary>
        private int ElementsBefore(int index, int[] buckets)
            => (from i in Enumerable.Range(0, index) select buckets[i]).Sum();


        /// <summary>Determines the index of the bucket in which k lies.</summary>
        private int FindIndex(int k, int[] buckets)
        {
            int high = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                high += buckets[i];
                if (k <= high) return i;
            }
            throw new InvalidOperationException();
        }

        private static int ObtainMaxBucketSize(int n)
            => obtainOnes(numberOfOnes: (int)Math.Log10(n) + 1);

        /// <summary>Recurrence returning an integer containing "n+1" ones: 1, 11, 111</summary>
        private static int obtainOnes(int numberOfOnes)
        {
            if (numberOfOnes == 1) return 1;

            int pow10 = (int)Math.Pow(10, numberOfOnes - 1);

            return pow10 + obtainOnes(numberOfOnes - 1);
        }

        public int NumberOfArithmeticSlices(int[] A)
        {
            int counts = 0;
            if (A.Length == 0)
            {
                return counts;
            }

            Dictionary<int, int>[] dp = new Dictionary<int, int>[A.Length];
            dp[0] = new Dictionary<int, int>();
            for (int i = 1; i < A.Length; i++)
            {
                dp[i] = new Dictionary<int, int>();
                for (int j = i - 1; j >= 0; j--)
                {
                    long diff = (long)A[i] - (long)A[j];
                    if (diff <= Int32.MinValue || diff > Int32.MaxValue) continue;
                    int df = (int)diff;
                    if (!dp[i].ContainsKey(df))
                    {
                        dp[i][df] = 0;
                    }

                    dp[i][df]++;

                    // Get j's dictionary for the given diff.
                    if (dp[j].ContainsKey(df))
                    {
                        var jsDiffCounts = dp[j][df];
                        dp[i][df] += jsDiffCounts;
                        counts += dp[j][df];
                    }
                }
            }

            return counts;

        }

        public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
        {
            var h1 = new HashSet<char>();
            var h2 = new HashSet<char>();

            for (int i = 0; i < s1.Length; i++)
                h1.Add(s1[i]);

            for (int i = 0; i < s2.Length; i++)
                h2.Add(s2[i]);

            var it = h2.GetEnumerator();
            while (it.MoveNext())
            {
                // if s2 contains something that s1 does not.
                if (!h1.Contains(it.Current)) return 0;
            }

            if (h1.Count() == 1 && h2.Count() == 1)
            {
                //For cases like "aaaaaaaaaaaa...." and "aa.."
                return ((n1 * s1.Length) / (n2 * s2.Length));
            }

            //Lens stores the length of a string that contains one "s2" and begins at index i.
            var lens = new int[s1.Length];

            for (int i = 0; i < s1.Length; i++)
            {
                int j = 0;
                int c = 0;

                while (j < s2.Length)
                {
                    if (s2[j] == s1[((i + c) % s1.Length)])
                        j++;
                    c++;
                }

                lens[i] = c - 1;
            }

            int count = 0;
            int total_length = s1.Length * n1;

            int temp = 0;
            int k = 0;
            int cur_index = 0;

            while (true)
            {
                k += lens[cur_index] + 1;
                if (k > total_length) break;

                temp++;
                if (temp == n2)
                {
                    count++;
                    temp = 0;
                }
                cur_index = (cur_index + lens[cur_index] + 1) % s1.Length;
            }

            return count;
        }
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            IList<String> res = new List<string>();
            if (words == null || words.Length == 0)
            {
                return res;
            }
            TrieNode root = new TrieNode();
            foreach ( String word in words)
            { // construct Trie tree
                if (word.Length == 0)
                {
                    continue;
                }
                addWord(word, root);
            }
            foreach (String word in words)
            { // test word is a concatenated word or not
                if (word.Length == 0)
                {
                    continue;
                }
                if (testWord(word.ToCharArray(), 0, root, 0))
                {
                    res.Add(word);
                }
            }
            return res;
        }
        public bool testWord(char[] chars, int index, TrieNode root, int count)
        { // count means how many words during the search path
            TrieNode cur = root;
            int n = chars.Length;
            for (int i = index; i < n; i++)
            {
                if (cur.sons[chars[i] - 'a'] == null)
                {
                    return false;
                }
                if (cur.sons[chars[i] - 'a'].isEnd)
                {
                    if (i == n - 1)
                    { // no next word, so test count to get result.
                        return count >= 1;
                    }
                    if (testWord(chars, i + 1, root, count + 1))
                    {
                        return true;
                    }
                }
                cur = cur.sons[chars[i] - 'a'];
            }
            return false;
        }
        public void addWord(String str, TrieNode root)
        {
            char[] chars = str.ToCharArray();
            TrieNode cur = root;
            foreach (char c in chars)
            {
                if (cur.sons[c - 'a'] == null)
                {
                    cur.sons[c - 'a'] = new TrieNode();
                }
                cur = cur.sons[c - 'a'];
            }
            cur.isEnd = true;
        }

        public double[] MedianSlidingWindow(int[] nums, int k)
        {
            List<double> llist = new List<double>();

            if (nums != null && nums.Length > 0 && k > 0)
            {
                int liPos1 = (k >> 1);
                int liPos2 = liPos1 + (k & 1) - 1;

                List<double> llistSlid = new List<double>();

                for (int i = 0; i < nums.Length; ++i)
                {
                    if (i >= k)
                    {
                        llistSlid.Remove(nums[i - k]);
                    }

                    int liIndex = llistSlid.BinarySearch(nums[i]);
                    if (liIndex < 0)
                    {
                        liIndex = ~liIndex;
                    }
                    llistSlid.Insert(liIndex, nums[i]);

                    if (i >= k - 1)
                        llist.Add(liPos1 == liPos2 ? llistSlid[liPos1] : ((llistSlid[liPos1] + llistSlid[liPos2]) / 2));
                }
            }

            return llist.ToArray<double>();
        }

        public int FindMinMoves(int[] machines)
        {
            int n = machines.Length, sum = 0;
            for (int i = 0; i < n; i++) sum += machines[i];

            if (sum % n != 0) return -1;
            int t = sum / n, d = 0, max = 0;
            for (int i = 0; i < n; i++)
            {
                int diff = (machines[i] - t); // dress surplus or deficit
                d += diff; // total surplus or deficit so far between index 0 .. i or how many dresses needs to move between 0..i and i..(n-1)
                max = Math.Max(max, Math.Abs(d)); // max point with maximum number of movement needed so far
                if (diff > 0) max = Math.Max(max, diff); // surplus machines cant give away more than one at a time
            }

            return max;
        }

        public int RemoveBoxes(int[] boxes)
        {
            if (boxes == null || boxes.Length == 0)
            {
                return 0;
            }

            int size = boxes.Length;
            int[,,] dp = new int[size,size,size];

            return get(dp, boxes, 0, size - 1, 1);
        }

        private int get(int[,,] dp, int[] boxes, int i, int j, int k)
        {
            if (i > j)
            {
                return 0;
            }
            else if (i == j)
            {
                return k * k;
            }
            else if (dp[i, j, k] != 0)
            {
                return dp[i, j, k];
            }
            else
            {
                int temp = get(dp, boxes, i + 1, j, 1) + k * k;

                for (int m = i + 1; m <= j; m++)
                {
                    if (boxes[i] == boxes[m])
                    {
                        temp = Math.Max(temp, get(dp, boxes, i + 1, m - 1, 1) + get(dp, boxes, m, j, k + 1));
                    }
                }

                dp[i, j, k] = temp;
                return temp;
            }
        }

        static int M = 1000000007;

        public int CheckRecord(int n)
        {
            long[] PorL = new long[n + 1]; // ending with P or L, no A
            long[] P = new long[n + 1]; // ending with P, no A
            PorL[0] = P[0] = 1; PorL[1] = 2; P[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                P[i] = PorL[i - 1];
                PorL[i] = (P[i] + P[i - 1] + P[i - 2]) % M;
            }

            long res = PorL[n];
            for (int i = 0; i < n; i++)
            { // inserting A into (n-1)-length strings
                long s = (PorL[i] * PorL[n - i - 1]) % M;
                res = (res + s) % M;
            }

            return (int)res;
        }
        const long radix = 10;

        //O(N) algorithm for creating a numerical palindrome
        private long MakePalindrome(long value, int length)
        {
            long exp = 1L;
            int mid = length / 2;
            long reverse = 0;
            int i = 0;

            //Truncate value
            while (i++ < mid)
            {
                exp *= radix;
            }
            value /= exp;


            i = 0;
            long temp = value;

            //233 ==> 23 + 2
            if (length % 2 == 1)
            {
                temp /= radix;
            }

            //Reverse truncated value
            while (i++ < mid)
            {
                reverse *= radix;
                reverse += temp % radix;
                temp /= radix;
            }

            value *= exp;
            value += reverse;

            return value;
        }

        //Digit value is reversed-order
        //(10)==> Digit 1 is 1, Digit 0 is 0
        private int DigitValue(long x, int n)
        {
            long exp = 1;

            while (n-- > 0)
            {
                exp *= radix;
            }

            x /= exp;
            x %= radix;

            return (int)x;
        }

        //Digit order is reversed; 10 ==> 1 @ 1 and 0 @ 0
        private long IncrementAtDigitIndex(long value, long source, int nIndex)
        {
            int i = 0;

            while (i++ < nIndex)
            {
                value *= radix;
            }

            return source + value;
        }

        private int Len(long z)
        {
            long exp = radix;
            int i = 1;
            while (exp <= z)
            {
                i++;
                exp *= radix;
            }
            return i;
        }

        private long FindHigherPalindrome(long limit)
        {
            int length = Len(limit);
            long result = MakePalindrome(limit, length);

            for (int i = length - 1; i >= 0; i--)
            {
                int left = DigitValue(limit, i);
                int right = DigitValue(result, i);
                if (left < right)
                {
                    break;
                }
                else if (left > right)
                {
                    int j = length / 2;//digit-order reversed
                    result = IncrementAtDigitIndex(1L, result, j);
                    // make it palindrome again
                    result = MakePalindrome(result, Len(length));
                    break;
                }
            }
            return result;
        }

        private long FindLowerPalindrome(long limit)
        {
            int length = Len(limit);
            long result = MakePalindrome(limit, length);

            for (int i = length - 1; i >= 0; i--)
            {
                int left = DigitValue(limit, i);
                int right = DigitValue(result, i);
                if (left > right)
                {
                    break;
                }
                else if (left < right)
                {
                    int j = length / 2;//digit-order reversed
                    result = IncrementAtDigitIndex(-1L, result, j);

                    if (length == 2 && result < 10)
                    {
                        result = 9;
                        break;
                    }

                    // make it palindrome again
                    result = MakePalindrome(result, Len(result));
                    break;
                }
            }
            return result;
        }

        public string NearestPalindromic1(string n)
        {
            string result = string.Empty;

            if (n.Length > 0)
            {
                long number = long.Parse(n);
                long low = FindLowerPalindrome(number - 1L);
                long high = FindHigherPalindrome(number + 1L);
                result = Math.Abs(number - low) > Math.Abs(number - high) ? high.ToString() : low.ToString();
            }

            return result;
        }

        public string NearestPalindromic(string n)
        {
            int len = n.Length;
            var c = Int64.Parse(n);
            if (n == "0")
                return "1";
            else if (len == 1)
                return (char)(n[0] - 1) + "";
            else if (n[0] == '1' && c % 10 == 0 && n.Substring(1).Replace("0", "") == "")
            {
                return (c - 1).ToString();
            }
            else if (n[0] == '1' && (c - 1) % 10 == 0 && (c - 1).ToString().Substring(1).Replace("0", "") == "")
            {
                return (c - 2).ToString();
            }
            else if (n.Replace("9", "") == "")
            {
                return (c + 2).ToString();
            }

            string result = BulidHalf(n);

            if (result == n)
            {
                Int64 add = 0;
                if (len % 2 == 0)
                {
                    add = Int64.Parse("11".PadRight(len / 2 + 1, '0'));
                }
                else
                {
                    add = Int64.Parse("1".PadRight(len / 2 + 1, '0'));
                }

                if (n[len / 2] == '0')
                {
                    add = 0 - add;
                }

                result = (c - add).ToString();
            }
            else
            {
                string r1 = BulidHalf((Int64.Parse(n) + Int64.Parse("1".PadRight(len / 2 + 1, '0'))).ToString());

                var r2 = BulidHalf((Int64.Parse(n) - Int64.Parse("1".PadRight(len / 2 + 1, '0'))).ToString());
                //Console.WriteLine(r1+","+r2);
                if (Math.Abs(Int64.Parse(r2) - c) <= Math.Abs(Int64.Parse(r1) - c))
                {
                    r1 = r2;
                }

                //Console.WriteLine(r1);
                if (Math.Abs(Int64.Parse(r1) - c) < Math.Abs(Int64.Parse(result) - c)
                || Math.Abs(Int64.Parse(r1) - c) == Math.Abs(Int64.Parse(result) - c) && Int64.Parse(r1) < Int64.Parse(result)
                )
                {
                    result = r1;
                }
            }
            return result;
        }

        private string BulidHalf(string n)
        {
            var len = n.Length;
            var half = n.Substring(0, len / 2);
            var arr = half.ToCharArray();
            Array.Reverse(arr);

            string result = "";
            if (len % 2 == 0)
            {
                result = half + new string(arr);
            }
            else
            {
                result = half + n[len / 2] + new string(arr);
            }

            return result;
        }

        public IList<Point> OuterTrees(Point[] points)
        {

            HashSet<Point> result = new HashSet<Point>();

            // Find the leftmost point
            Point first = points[0];
            int firstIndex = 0;
            for (int i = 1; i < points.Length; i++)
            {
                if (points[i].x < first.x)
                {
                    first = points[i];
                    firstIndex = i;
                }
            }
            result.Add(first);

            Point cur = first;
            int curIndex = firstIndex;
            do
            {
                Point next = points[0];
                int nextIndex = 0;
                for (int i = 1; i < points.Length; i++)
                {
                    if (i == curIndex) continue;
                    int cross = crossProductLength(cur, points[i], next);
                    if (nextIndex == curIndex || cross > 0 ||
                            // Handle collinear points
                            (cross == 0 && distance(points[i], cur) > distance(next, cur)))
                    {
                        next = points[i];
                        nextIndex = i;
                    }
                }
                // Handle collinear points
                for (int i = 0; i < points.Length; i++)
                {
                    if (i == curIndex) continue;
                    int cross = crossProductLength(cur, points[i], next);
                    if (cross == 0)
                    {
                        result.Add(points[i]);
                    }
                }

                cur = next;
                curIndex = nextIndex;

            } while (curIndex != firstIndex);

            return result.ToList();
        }

        private int crossProductLength(Point A, Point B, Point C)
        {
            // Get the vectors' coordinates.
            int BAx = A.x - B.x;
            int BAy = A.y - B.y;
            int BCx = C.x - B.x;
            int BCy = C.y - B.y;

            // Calculate the Z coordinate of the cross product.
            return (BAx * BCy - BAy * BCx);
        }

        private int distance(Point p1, Point p2)
        {
            return (p1.x - p2.x) * (p1.x - p2.x) + (p1.y - p2.y) * (p1.y - p2.y);
        }

        public bool IsValid(string code)
        {
            var count = 0; //tag count
            var stack = new Stack<Tag>();
            var tagname = new Stack<int>();
            var isCDataProcessing = false;
            for (var i = 0; i < code.Length; i++)
            {
                if (code[i] == ' ') continue;
                var sub = code.Substring(i);
                if (isCDataProcessing)
                {
                    if (sub.StartsWith("]]>"))
                    {
                        isCDataProcessing = false;
                        i += 2;
                        continue;
                    }
                }
                else
                {
                    if (sub.StartsWith("<![CDATA["))
                    {
                        if (stack.Count == 0) return false;

                        isCDataProcessing = true;
                        i += 8;
                        continue;
                    }

                    if (code[i] == '<')
                    {
                        var next = code.IndexOf('>', i + 1);
                        if (next <= 0) return false;

                        var name = code.Substring(i + 1, next - (i + 1));
                        if (name.Length < 1) return false;
                        if (code[i + 1] == '/')
                        {
                            name = name.Substring(1);
                            //end tag

                            if (stack.Count == 0) return false;
                            var tag = stack.Pop();
                            if (!tag.TagName.Equals(name)) return false;
                        }
                        else
                        {
                            if (count > 0 && stack.Count == 0) return false;

                            //start tag
                            var tag = new Tag()
                            {
                                TagName = name,
                            };
                            stack.Push(tag);
                            count++;
                        }
                        if (!ValidateTagName(name)) return false;
                        i = next;
                    }
                    else if (count == 0)
                    {
                        return false;
                    }
                    else if (stack.Count == 0)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }


        /// <summary>
        /// rule3: A valid TAG_NAME only contain upper-case letters, and has length in range [1,9]. Otherwise, the TAG_NAME is invalid.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ValidateTagName(string name)
        {
            foreach (var n in name)
            {
                if (!(n >= 'A' && n <= 'Z')) return false;
            }
            return name.Length > 0 && name.Length < 10 && name.Equals(name.ToUpper());
        }
        public class Tag
        {
            public string TagName;
            public string TagValue;

        }

        public int FindIntegers(int num)
        {
            if (num == 0)
            {
                return 1;
            }
            else if (num == 1)
            {
                return 2;
            }

            string s = Convert.ToString(num, 2);

            int len = s.Length;

            var dp1 = new int[len];
            var dp0 = new int[len];
            dp0[len - 1] = 1;
            dp1[len - 1] = 1;

            for (int i = len - 2; i >= 0; i--)
            {
                dp0[i] = dp0[i + 1] + dp1[i + 1];
                dp1[i] = dp0[i + 1];
            }

            int result = dp1[0] + dp0[0];

            for (int i = 1; i < len; i++)
            {
                if (s[i] == '1')
                {
                    if (s[i - 1] == '1')
                    {
                        break;
                    }
                }
                else if (s[i - 1] == '0')
                {
                    result -= dp1[i];
                }
            }

            return result;
        }

        public int KInversePairs(int n, int k)
        {
            int mod = 1000000007;
            if (k > n * (n - 1) / 2 || k < 0) return 0;
            if (k == 0 || k == n * (n - 1) / 2) return 1;
            long[,] dp = new long[n + 1,k + 1];
            dp[2,0] = 1;
            dp[2,1] = 1;
            for (int i = 3; i <= n; i++)
            {
                dp[i,0] = 1;
                for (int j = 1; j <= Math.Min(k, i * (i - 1) / 2); j++)
                {
                    dp[i,j] = dp[i,j - 1] + dp[i - 1,j];
                    if (j >= i) dp[i,j] -= dp[i - 1,j - i];
                    dp[i,j] = (dp[i,j] + mod) % mod;
                }
            }
            return (int)dp[n,k];
        }

        public int ScheduleCourse(int[,] courses)
        {
            var c = courses.To2D();
            Array.Sort(c, Comparer<int[]>.Create((a, b) => a[1] == b[1] ? a[0].CompareTo(b[0]) : a[1].CompareTo(b[1])));
            courses = c.To2D();

            var sl = new List<int>();

            var n = courses.GetLength(0);
            var timeTillNow = 0;
            for (var i = 0; i < n; ++i)
            {
                if (timeTillNow + courses[i, 0] <= courses[i, 1]) // valid
                {
                    Add(sl, courses[i, 0]);
                    timeTillNow += courses[i, 0];
                }
                else if (sl.Last() > courses[i, 0]) // we already sorted end time, if time cost is small the pre, always better to switch
                {
                    timeTillNow += courses[i, 0] - sl.Last();
                    sl.RemoveAt(sl.Count - 1);
                    Add(sl, courses[i, 0]);
                }
                // time cost even big , ignore.
            }

            return sl.Count;
        }

        public void Add(List<int> l, int val)
        {
            var index = l.BinarySearch(val);
            index = index < 0 ? ~index : index;
            l.Insert(index, val);
        }

        public int[] SmallestRange(IList<IList<int>> nums)
        {
            var list = new List<int>();
            int len = nums.Count;
            var indexArr = new int[len];
            for (int i = 0; i < len; i++)
            {
                indexArr[i] = nums[i].Count - 1;
                int index = FindIndex(list, i, nums, indexArr);
                list.Insert(index, i);
            }
            //Console.WriteLine(string.Join(",",indexArr));
            int[] result = new int[] { nums[list.First()][indexArr[list.First()]], nums[list.Last()][indexArr[list.Last()]] };

            while (true)
            {
                var lastIndex = list.Last();
                if (--indexArr[lastIndex] == -1)
                    break;
                //Console.WriteLine(j+","+indexArr[j]);
                list.RemoveAt(list.Count - 1);

                list.Insert(FindIndex(list, lastIndex, nums, indexArr), lastIndex);

                int n1 = nums[list.First()][indexArr[list.First()]];
                int n2 = nums[list.Last()][indexArr[list.Last()]];

                if (n2 - n1 < result[1] - result[0] || n2 - n1 == result[1] - result[0] && n1 < result[0])
                {
                    result[0] = n1;
                    result[1] = n2;
                }
                //Console.WriteLine(string.Join(",",list));
            }

            return result;
        }

        private int FindIndex(List<int> list, int index, IList<IList<int>> nums, int[] indexArr)
        {
            if (list.Count == 0)
                return 0;

            int low = 0;
            int high = list.Count - 1;
            int v = nums[index][indexArr[index]];
            while (low < high - 1)
            {
                int mid = low + (high - low) / 2;

                int mid_v = nums[list[mid]][indexArr[list[mid]]];

                if (mid_v == v)
                    return mid;
                else if (mid_v < v)
                    low = mid;
                else
                    high = mid;
            }
            if (nums[list[low]][indexArr[list[low]]] >= v)
                return low;
            else if (nums[list[high]][indexArr[list[high]]] >= v)
                return high;
            else
                return high + 1;
        }
        public int NumDecodings(string s)
        {
            var v2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var v1 = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int mod = 1000000007;
            int len = s.Length;
            if (len == 0)
                return 0;

            for (int i = 0; i < len; i++)
            {
                var newv1 = new int[10];
                var newv2 = new int[10];
                int sumTotal = 0;
                foreach (var v in v1)
                {
                    sumTotal += v;
                    sumTotal %= mod;
                }
                foreach (var v in v2)
                {
                    sumTotal += v;
                    sumTotal %= mod;
                }
                if (s[i] == '*')
                {
                    for (int j = 1; j <= 9; j++)
                    {
                        if (i > 0)
                        {
                            newv2[j] += v1[1];
                            if (j <= 6)
                                newv2[j] += v1[2];
                            newv2[j] %= mod;
                        }
                        newv1[j] = i == 0 ? 1 : sumTotal;
                    }
                }
                else
                {
                    if (i > 0)
                    {
                        newv2[s[i] - '0'] += v1[1];
                        if (s[i] >= '0' && s[i] <= '6')
                            newv2[s[i] - '0'] += v1[2];
                        newv2[s[i] - '0'] %= mod;
                    }

                    if (s[i] != '0')
                    {
                        newv1[s[i] - '0'] = i == 0 ? 1 : sumTotal;
                    }
                }
                v1 = newv1;
                v2 = newv2;
            }
            int result = 0;
            foreach (var v in v1)
            {
                result += v;
                result %= mod;
            }
            foreach (var v in v2)
            {
                result += v;
                result %= mod;
            }
            return result;
        }

        public int ProfitableSchemes(int G, int P, int[] group, int[] profit)
        {
            int[,] dp = new int[P + 1, G + 1];
            dp[0, 0] = 1;
            int res = 0, mod = (int)1e9 + 7;
            for (int k = 0; k < group.Length; k++)
            {
                int g = group[k], p = profit[k];
                for (int i = P; i >= 0; i--)
                    for (int j = G - g; j >= 0; j--)
                        dp[Math.Min(i + p, P), j + g] = (dp[Math.Min(i + p, P), j + g] + dp[i, j]) % mod;
            }
            for (int i = 0; i < dp.Length; i++) res = (res + dp[P, i]) % mod;
            return res;
        }

        public int StrangePrinter(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }

            int n = s.Length;
            int[,] dp = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                dp[i,i] = 1;
                if (i < n - 1)
                {
                    dp[i,i + 1] = s[i] == s[i + 1] ? 1 : 2;
                }
            }

            for (int len = 2; len < n; len++)
            {
                for (int start = 0; start + len < n; start++)
                {
                    dp[start,start + len] = len + 1;
                    for (int k = 0; k < len; k++)
                    {
                        int temp = dp[start,start + k] + dp[start + k + 1,start + len];
                        dp[start,start + len] = Math.Min(
                            dp[start,start + len],
                            s[start + k] == s[start + len] ? temp - 1 : temp
                        );
                    }
                }
            }

            return dp[0,n - 1];
        }

        public int FindKthNumber(int m, int n, int k)
        {
            int low = 1, high = m * n + 1;

            while (low < high)
            {
                int mid = low + (high - low) / 2;
                int c = count(mid, m, n);
                if (c >= k) high = mid;
                else low = mid + 1;
            }

            return high;
        }

        private int count(int v, int m, int n)
        {
            int count = 0;
            for (int i = 1; i <= m; i++)
            {
                int temp = Math.Min(v / i, n);
                count += temp;
            }
            return count;
        }

        bool res = false;
        double eps = 0.001;

        public bool JudgePoint24(int[] nums)
        {
            List<Double> arr = new List<double>();
            foreach (int n in nums) arr.Add((double)n);
            helper(arr);
            return res;
        }

        private void helper(List<Double> arr)
        {
            if (res) return;
            if (arr.Count() == 1)
            {
                if (Math.Abs(arr[0] - 24.0) < eps)
                    res = true;
                return;
            }
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    List<Double> next = new List<double>();
                    Double p1 = arr[i], p2 = arr[j];
                    next.Add(p1 + p2);
                    next.Add(p1 - p2);
                    next.Add(p2 - p1);
                    next.Add(p1 * p2);
                    if (Math.Abs(p2) > eps) next.Add(p1 / p2);
                    if (Math.Abs(p1) > eps) next.Add(p2 / p1);

                    arr.Remove(i);
                    arr.Remove(j);
                    foreach (Double n in next)
                    {
                        arr.Add(n);
                        helper(arr);
                        arr.Remove(arr.Count - 1);
                    }
                    arr.Add(p2);
                    arr.Add(p1);
                }
            }
        }

        public int[] FindRedundantDirectedConnection(int[,] edges)
        {
            int[] can1 = { -1, -1 };
            int[] can2 = { -1, -1 };
            int[] parent = new int[edges.Length + 1];
            for (int i = 0; i < edges.Length; i++)
            {
                if (parent[edges[i,1]] == 0)
                {
                    parent[edges[i,1]] = edges[i,0];
                }
                else
                {
                    can2 = new int[] { edges[i,0], edges[i,1] };
                    can1 = new int[] { parent[edges[i,1]], edges[i,1] };
                    edges[i,1] = 0;
                }
            }
            for (int i = 0; i < edges.Length; i++)
            {
                parent[i] = i;
            }
            for (int i = 0; i < edges.Length; i++)
            {
                if (edges[i,1] == 0)
                {
                    continue;
                }
                int child = edges[i,1], father = edges[i,0];
                if (root(parent, father) == child)
                {
                    if (can1[0] == -1)
                    {
                        int[] result = new int[edges.GetLength(1)];
                        for(int index = 0; index < edges.GetLength(1); index++)
                        {
                            result[index] = edges[i, index];
                        }
                        return result;
                    }
                    return can1;
                }
                parent[child] = father;
            }
            return can2;
        }


        int root(int[] parent, int i)
        {
            while (i != parent[i])
            {
                parent[i] = parent[parent[i]];
                i = parent[i];
            }
            return i;
        }

        public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
        {
            int[,] dp = new int[4,nums.Length + 1];
            int sum = 0;
            int[] accu = new int[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                accu[i] = sum;
            }
            int[,] id = new int[4,nums.Length + 1];
            for (int i = 1; i < 4; i++)
            {
                for (int j = k - 1; j < nums.Length; j++)
                {
                    int tmpmax = j - k < 0 ? accu[j] : accu[j] - accu[j - k] + dp[i - 1,j - k];
                    if (j - k >= 0)
                    {
                        dp[i,j] = dp[i,j - 1];
                        id[i,j] = id[i,j - 1];
                    }
                    if (j > 0 && tmpmax > dp[i,j - 1])
                    {
                        dp[i,j] = tmpmax;
                        id[i,j] = j - k + 1;
                    }
                }
            }
            int[] res = new int[3];
            res[2] = id[3,nums.Length - 1];
            res[1] = id[2,res[2] - 1];
            res[0] = id[1,res[1] - 1];
            return res;
        }
        public int MinStickers(string[] stickers, string target)
        {
            int n = target.Length, m = 1 << n; // if target has n chars, there will be m=2^n subset of characters in target
            int[] dp = new int[m];
            for (int i = 0; i < m; i++) dp[i] = int.MaxValue; // use index 0 - 2^n as bitmaps to represent each subset of all chars in target
            dp[0] = 0; // first thing we know is : dp[empty set] requires 0 stickers,
            for (int i = 0; i < m; i++)
            { // for every subset i, start from 000...000
                if (dp[i] == int.MaxValue) continue;
                foreach (String s in stickers)
                { // try use each sticker as an char provider to populate 1 of its superset, to do that:
                    int sup = i;
                    foreach (char c in s.ToCharArray())
                    { // for each char in the sticker, try apply it on a missing char in the subset of target
                        for (int r = 0; r < n; r++)
                        {
                            if (target[r] == c && ((sup >> r) & 1) == 0)
                            {
                                sup |= 1 << r;
                                break;
                            }
                        }
                    }
                    // after you apply all possible chars in a sticker, you get an superset that take 1 extra sticker than subset
                    // would take, so you can try to update the superset's minsticker number with dp[sub]+1;
                    dp[sup] = Math.Min(dp[sup], dp[i] + 1);
                }
            }
            return dp[m - 1] != int.MaxValue ? dp[m - 1] : -1;

        }

        public IList<int> FallingSquares(int[,] positions)
        {
            int[] ends = new int[positions.GetLength(0) * 2];
            for (int i = 0; i < positions.GetLength(0); i++)
            {
                ends[i * 2 + 0] = positions[i,0];
                ends[i * 2 + 1] = positions[i,0] + positions[i,1];
            }
            Array.Sort(ends);

            int[] ceilings = new int[ends.Length - 1];
            int maxAll = 0;
            IList<int> results = new List<int>();
            for (int i = 0; i < positions.GetLength(0); i++)
            {
                int X = positions[i,0];
                int x = Array.BinarySearch(ends, X);
                //assert x>= 0;
                int maxCeiling = 0;
                int Y = X + positions[i,1];
                for (int y = x; ends[y] < Y; y++)
                    maxCeiling = Math.Max(maxCeiling, ceilings[y]);
                maxCeiling += (Y - X);
                for (int y = x; ends[y] < Y; y++)
                    ceilings[y] = maxCeiling;
                maxAll = Math.Max(maxAll, maxCeiling);
                results.Add(maxAll);
            }
            return results;
        }

        public int SmallestDistancePair(int[] nums, int k)
        {
            int len = nums.Length;
            int len2 = 1000000;
            int[] dp = new int[len2];
            for (int i = 1; i < len; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int dif = Math.Abs(nums[i] - nums[j]);
                    dp[dif]++;
                }
            }
            int sum = 0;
            for (int i = 0; i < len2; i++)
            {
                sum += dp[i];
                if (sum >= k) return i;
            }
            return 0;
        }

        public string CountOfAtoms(string formula)
        {
            string result = string.Empty;
            // "K4(ON(SO3)2)2"
            int open_brackets = 0;
            var d = new Dictionary<string, int>();
            var name_stack = new Stack<string>();
            var value_stack = new Stack<int>();

            for (int i = 0; i < formula.Length; i++)
            {
                string atom = string.Empty;
                //(H2O)2
                if (formula[i] == '(')
                {
                    open_brackets++;
                    name_stack.Push("(");
                    value_stack.Push(-1);
                }
                else if (formula[i] == ')')
                {
                    open_brackets--;

                    i++;
                    while (i < formula.Length && char.IsDigit(formula[i]))
                    {
                        atom += formula[i];
                        i++;
                    }

                    i--;
                    int mul = atom.Length > 0 ? int.Parse(atom) : 1;

                    if (open_brackets > 0)
                    {
                        var temp_name_stack = new Stack<string>();
                        var temp_value_stack = new Stack<int>();

                        while (name_stack.Count > 0 && name_stack.Peek() != "(")
                        {
                            temp_name_stack.Push(name_stack.Pop());
                            temp_value_stack.Push(value_stack.Pop() * mul);
                        }

                        name_stack.Pop();
                        value_stack.Pop();

                        while (temp_name_stack.Count > 0)
                        {
                            name_stack.Push(temp_name_stack.Pop());
                            value_stack.Push(temp_value_stack.Pop());
                        }
                    }
                    else
                    {
                        while (name_stack.Count > 0 && name_stack.Peek() != "(")
                        {
                            if (d.ContainsKey(name_stack.Peek()))
                            {
                                d[name_stack.Pop()] += mul * value_stack.Pop();
                            }
                            else
                            {
                                d.Add(name_stack.Pop(), mul * value_stack.Pop());
                            }
                        }

                        name_stack.Pop();
                        value_stack.Pop();
                    }
                }


                else if (char.IsLetter(formula[i]) && char.IsUpper(formula[i]))
                {
                    atom += formula[i];
                    i++;

                    while (i < formula.Length && char.IsLower(formula[i]))
                    {
                        atom += formula[i];
                        i++;
                    }

                    string value = "";

                    while (i < formula.Length && char.IsDigit(formula[i]))
                    {
                        value += formula[i];
                        i++;
                    }

                    i--;
                    int m = value.Length > 0 ? int.Parse(value) : 1;
                    if (open_brackets > 0)
                    {
                        name_stack.Push(atom);
                        value_stack.Push(m);
                    }
                    else
                    {
                        if (d.ContainsKey(atom))
                        {
                            d[atom] += m;
                        }
                        else
                        {
                            d.Add(atom, m);
                        }
                    }
                }
            }

            while (name_stack.Count > 0)
            {
                if (d.ContainsKey(name_stack.Peek()))
                {
                    d[name_stack.Pop()] += value_stack.Pop();
                }
                else
                {
                    d.Add(name_stack.Pop(), value_stack.Pop());
                }
            }

            d.OrderBy((x) => x.Key).ToList().ForEach(y =>
            {
                result += y.Key;
                if (y.Value > 1)
                {
                    result += y.Value;
                }
            });

            return result;
        }

        public int CountPalindromicSubsequences(string S)
        {
            int len = S.Length;
            int[,] dp = new int[len,len];

            char[] chs = S.ToCharArray();
            for (int i = 0; i < len; i++)
            {
                dp[i,i] = 1;   // Consider the test case "a", "b" "c"...
            }

            for (int distance = 1; distance < len; distance++)
            {
                for (int i = 0; i < len - distance; i++)
                {
                    int j = i + distance;
                    if (chs[i] == chs[j])
                    {
                        int low = i + 1;
                        int high = j - 1;

                        /* Variable low and high here are used to get rid of the duplicate*/

                        while (low <= high && chs[low] != chs[j])
                        {
                            low++;
                        }
                        while (low <= high && chs[high] != chs[j])
                        {
                            high--;
                        }
                        if (low > high)
                        {
                            // consider the string from i to j is "a...a" "a...a"... where there is no character 'a' inside the leftmost and rightmost 'a'
                            /* eg:  "aba" while i = 0 and j = 2:  dp[1][1] = 1 records the palindrome{"b"}, 
                              the reason why dp[i + 1][j  - 1] * 2 counted is that we count dp[i + 1][j - 1] one time as {"b"}, 
                              and additional time as {"aba"}. The reason why 2 counted is that we also count {"a", "aa"}. 
                              So totally dp[i][j] record the palindrome: {"a", "b", "aa", "aba"}. 
                              */

                            dp[i,j] = dp[i + 1,j - 1] * 2 + 2;
                        }
                        else if (low == high)
                        {
                            // consider the string from i to j is "a...a...a" where there is only one character 'a' inside the leftmost and rightmost 'a'
                            /* eg:  "aaa" while i = 0 and j = 2: the dp[i + 1][j - 1] records the palindrome {"a"}.  
                              the reason why dp[i + 1][j  - 1] * 2 counted is that we count dp[i + 1][j - 1] one time as {"a"}, 
                              and additional time as {"aaa"}. the reason why 1 counted is that 
                              we also count {"aa"} that the first 'a' come from index i and the second come from index j. So totally dp[i][j] records {"a", "aa", "aaa"}
                             */
                            dp[i,j] = dp[i + 1,j - 1] * 2 + 1;
                        }
                        else
                        {
                            // consider the string from i to j is "a...a...a... a" where there are at least two character 'a' close to leftmost and rightmost 'a'
                            /* eg: "aacaa" while i = 0 and j = 4: the dp[i + 1][j - 1] records the palindrome {"a",  "c", "aa", "aca"}. 
                               the reason why dp[i + 1][j  - 1] * 2 counted is that we count dp[i + 1][j - 1] one time as {"a",  "c", "aa", "aca"}, 
                               and additional time as {"aaa",  "aca", "aaaa", "aacaa"}.  Now there is duplicate :  {"aca"}, 
                               which is removed by deduce dp[low + 1][high - 1]. So totally dp[i][j] record {"a",  "c", "aa", "aca", "aaa", "aaaa", "aacaa"}
                               */
                            dp[i,j] = dp[i + 1,j - 1] * 2 - dp[low + 1,high - 1];
                        }
                    }
                    else
                    {
                        dp[i,j] = dp[i,j - 1] + dp[i + 1,j] - dp[i + 1,j - 1];  //s.charAt(i) != s.charAt(j)
                    }
                    dp[i,j] = dp[i,j] < 0 ? dp[i,j] + 1000000007 : dp[i,j] % 1000000007;
                }
            }

            return dp[0,len - 1];
        }

        public int Evaluate(string expression)
        {
            int i = 0;
            return EvaluateInternal(ref i, expression, new Dictionary<string, int>());
        }

        public int EvaluateInternal(ref int i, string str, Dictionary<string, int> scopedvalues)
        {
            if (string.IsNullOrEmpty(str) || i >= str.Length) return 0;
            if (str[i] == '(') i++;
            string operation = ""; //Find out what operation it is, this remains constant for this frame of recursion.
            while (i < str.Length && str[i] != ' ')
            {
                operation += str[i];
                i++;
            }
            i++;
            var current_scopedvalues = new Dictionary<string, int>(scopedvalues);//using parents first

            while (i < str.Length && str[i] != ')') // Until you reeached the end of expression
            {
                var args = new object[2]; //There  are always 2 entites involved , only except for let statements when you have to return it
                for (int count = 0; count < 2; count++)
                {
                    if (str[i] == '(') //It is an expression evaluate it
                        args[count] = EvaluateInternal(ref i, str, current_scopedvalues);
                    else //Either it is a variable like x or a number
                    {
                        var temp = string.Empty;
                        while (i < str.Length && str[i] != ' ' && str[i] != ')')
                        {
                            temp += str[i];
                            i++;
                        }
                        args[count] = temp;
                    }

                    if (str[i] == ')') break; // If you have reached end, only applicable for let
                    i++;
                }
                switch (operation)
                {
                    case "let":
                        if (str[i] == ')')
                        {
                            i++;
                            return GetValue(args[0], current_scopedvalues);
                        }
                        var variable = args[0].ToString();//For let the first is always a variable
                        var value = GetValue(args[1], current_scopedvalues);
                        if (current_scopedvalues.ContainsKey(variable))
                            current_scopedvalues[variable] = value;
                        else
                            current_scopedvalues.Add(variable, value);
                        break;
                    case "add":
                    case "mult":
                        var first = GetValue(args[0], current_scopedvalues);
                        var second = GetValue(args[1], current_scopedvalues);
                        i++;
                        if (operation.Equals("add")) return first + second;
                        return first * second;
                    default:
                        break;
                }
            }
            return 0;
        }

        private int GetValue(object o, Dictionary<string, int> values)
        {
            //object o must be a number or a variable present in values
            int res = 0;
            if (int.TryParse(o.ToString(), out res))
            {
                return res;
            }

            return values[o.ToString()];
        }
        private void Fill(int[,] source, int n, int value)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    source[i, j] = value;
                }
            }
        }

        public int CherryPickup(int[,] grid)
        {
            int n = grid.GetUpperBound(0) + 1;
            // dp holds maximum # of cherries two k-length paths can pickup.
            // The two k-length paths arrive at (i, k - i) and (j, k - j), 
            // respectively.
            int[,] dp = new int[n, n];//Initial DP

            Fill(dp, n, -1);

            dp[0, 0] = grid[0, 0]; // length k = 0

            // maxK: number of steps from (0, 0) to (n-1, n-1).
            int maxK = (n - 1) << 1;

            for (int k = 1; k <= maxK; k++)
            { // for every path k
                int[,] curr = new int[n, n];//Create a DP for this path

                Fill(curr, n, -1);

                // one path of length k arrive at (i, k - i) 
                for (int i = 0; i < n && i <= k; i++)
                {
                    // another path of length k arrive at (j, k - j)
                    for (int j = 0; j < n && j <= k; j++)
                    {

                        if ((k - i < n && grid[i, k - i] < 0) || (k - j < n && grid[j, k - j] < 0))
                        { // both paths needs to be able to pass-through
                            continue;
                        }

                        int cherries = dp[i, j]; // # of cherries picked up by the two (k-1)-length paths.
                                                 // See the figure below for an intuitive understanding

                        if (i > 0 && j > 0)
                        {
                            cherries = Math.Max(cherries, dp[i - 1, j - 1]);
                        }
                        if (i > 0)
                        {
                            cherries = Math.Max(cherries, dp[i - 1, j]);
                        }
                        if (j > 0)
                        {
                            cherries = Math.Max(cherries, dp[i, j - 1]);
                        }

                        // No viable way to arrive at (i, k - i)-(j, k-j).
                        if (cherries < 0) continue;

                        // Pickup cherries at (i, k - i) and (j, k -j ) if i != j.
                        // Otherwise, pickup (i, k-i). 
                        if (k - i < n)
                        {
                            cherries += grid[i, k - i];
                        }
                        if (k - j < n)
                        {
                            cherries += (i == j ? 0 : grid[j, k - j]);
                        }

                        curr[i, j] = cherries;
                    }
                }
                dp = curr;//Set previous DP to this DP
            }

            return Math.Max(dp[n - 1, n - 1], 0);
        }
        public int ContainVirus(int[,] grid)
        {
            int[] cost = new int[] { 0 };
            while (check(grid, cost)) ;
            return cost[0];
        }
        private bool check(int[,] grid, int[] cost)
        {
            // update every day information and return false if no improvement can be made
            int count = 1;
            int max = -1;
            bool flag = false;
            List<int[]> info = new List<int[]>();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] == 1)
                    {
                        count++;
                        int[,] walls = new int[grid.GetLength(0),grid.GetLength(1)];
                        int[] res = new int[2];
                        grid[i,j] = count;
                        dfs(i, j, grid, count, walls, res);
                        if (res[0] != 0) flag = true;
                        if (max == -1 || res[0] > info[max][0])
                        {
                            max = count - 2;
                        }
                        info.Add(res);
                    }
                }
            }
            if (count == 1)
            {
                return false;
            }
            cost[0] += info[max][1];
            update(grid, max + 2);
            return flag;
        }
        private void dfs(int row, int col, int[,] grid, int count, int[,] walls, int[] res)
        {
            //dfs and record number of walls need to block this area and how many 0s are under infection
            int[] shiftX = new int[] { 1, 0, -1, 0 };
            int[] shiftY = new int[] { 0, 1, 0, -1 };

            for (int i = 0; i < 4; i++)
            {
                int newRow = row + shiftX[i];
                int newCol = col + shiftY[i];
                if (newRow >= 0 && newRow < grid.Length && newCol >= 0 && newCol < grid.GetLength(0))
                {
                    if (grid[newRow,newCol] == 1)
                    {
                        grid[newRow,newCol] = count;
                        dfs(newRow, newCol, grid, count, walls, res);
                    }
                    else if (grid[newRow,newCol] == 0)
                    {
                        if (walls[newRow,newCol] == 0) res[0]++;
                        if ((walls[newRow,newCol] & 1 << i) == 0)
                        {
                            res[1]++;
                            walls[newRow,newCol] |= 1 << i;
                        }
                    }
                }
            }
        }
        private void update(int[,] grid, int quarantine)
        {
            //set the new infected area and set blocked area to be -1
            int[] shiftX = new int[] { 1, 0, -1, 0 };
            int[] shiftY = new int[] { 0, 1, 0, -1 };

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i,j] > 1 && grid[i,j] != quarantine)
                    {
                        for (int k = 0; k < 4; k++)
                        {
                            int newRow = i + shiftX[k];
                            int newCol = j + shiftY[k];
                            if (newRow >= 0 && newRow < grid.GetLength(0) && newCol >= 0 && newCol < grid.GetLength(0) && grid[newRow,newCol] == 0)
                            {
                                grid[newRow,newCol] = 1;
                            }
                        }
                        grid[i,j] = 1;
                    }
                    else if (grid[i,j] == quarantine)
                    {
                        grid[i,j] = -1;
                    }
                }
            }
        }

        public string MakeLargestSpecial(string S)
        {
            int count = 0, i = 0;
            IList<String> res = new List<String>();
            for (int j = 0; j < S.Length; ++j)
            {
                if (S[j] == '1') count++;
                else count--;
                if (count == 0)
                {
                    res.Add('1' + MakeLargestSpecial(S.Substring(i + 1, j-i-1)) + '0');
                    i = j + 1;
                }
            }
            res.Reverse();
            
            //Collections.sort(res, Collections.reverseOrder());
            return String.Join("", res);
        }

        public int IntersectionSizeTwo(int[,] intervals)
        {
            List<int[]> input = Load(intervals);
            Sort(input);
            return Exam(input);
        }

        private List<int[]> Load(int[,] intervals)
        {
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < intervals.GetLength(0); i++)
            {
                result.Add(new int[] { intervals[i, 0], intervals[i, 1] });
            }
            return result;
        }

        private void Sort(List<int[]> list)
        {
            list.Sort((x1, x2) => {
                if (x1[1] == x2[1])
                {
                    return x1[0] - x2[0];
                }
                return x1[1] - x2[1];
            });
        }

        private int Exam(List<int[]> list)
        {
            int result = 2;

            // maintain the best two points
            int left = list[0][1] - 1, right = list[0][1];
            for (int i = 1; i < list.Count; i++)
            {
                int[] current = list[i];

                // check the changes brought by the new interval
                int start = current[0], end = current[1];
                if (start < right && start > left)
                {
                    result++;
                    if (end == right)
                    {
                        left = right - 1;
                    }
                    else
                    {
                        left = right;
                        right = end;
                    }
                }
                else if (start == right)
                {
                    result++;
                    left = right;
                    right = end;
                }
                else if (start > right)
                {
                    result += 2;
                    left = end - 1;
                    right = end;
                }
            }
            return result;
        }

        public int MinSwapsCouples(int[] row)
        {

            var swaps = 0;

            for (int i = 0; i < row.Length; i++)
            {
                var isEven = row[i] % 2 == 0;
                var significantOther = isEven ? row[i] + 1 : row[i] - 1;

                if (row[i + 1] != significantOther)
                {
                    swaps++;

                    var j = i + 1;
                    while (row[j] != significantOther) j++;

                    Swap(row, i + 1, j);
                }

                i++;                // Go to the next couple;
            }

            return swaps;
        }


        private void Swap(int[] row, int i, int j)
        {
            var temp = row[i];
            row[i] = row[j];
            row[j] = temp;
        }

        public class ExpressionBuilder
        {
            public Dictionary<string, int> TokenVals { get; set; }
            public ExpressionBuilder(Dictionary<string, int> tokenVals)
            {
                this.TokenVals = tokenVals;
            }

            public Expression GetExpression(string token)
            {
                int constVal;
                bool isValue = Int32.TryParse(token, out constVal);
                if (isValue)
                {
                    return new Expression()
                    {
                        ConstantVal = constVal
                    };
                }

                if (TokenVals.ContainsKey(token))
                {
                    return new Expression
                    {
                        ConstantVal = TokenVals[token]
                    };
                }

                Expression r = new Expression();
                r.Terms.Add(token, 1);
                return r;
            }
        }

        public class Expression
        {
            public Expression()
            {
                this.Terms = new Dictionary<string, int>();
            }

            public override string ToString()
            {
                var returnValue = this.ToList();
                return String.Join(" + ", returnValue);
            }

            public List<string> ToList()
            {
                // Order all the terms in order of length and then by lex value.
                var orderedTerms = this.Terms.Where(k => k.Value != 0).OrderByDescending(k => k.Key.Split(new char[] { '*' }).Length).ThenBy(k => k.Key).ToList();
                var returnValue = new List<string>();
                foreach (var ot in orderedTerms)
                {
                    returnValue.Add(ot.Value.ToString() + "*" + ot.Key);
                }

                if (this.ConstantVal != 0)
                {
                    returnValue.Add(this.ConstantVal.ToString());
                }

                return returnValue;
            }

            public int ConstantVal { get; set; }
            public Dictionary<string, int> Terms { get; set; }
            public static Expression Add(Expression exp1, Expression exp2)
            {
                Expression result = new Expression();
                result.ConstantVal = exp1.ConstantVal + exp2.ConstantVal;
                result.Terms = new Dictionary<string, int>(exp1.Terms);
                foreach (var t in exp2.Terms)
                {
                    int newVal = (result.Terms.ContainsKey(t.Key) ? result.Terms[t.Key] : 0) + t.Value;
                    result.AddTerm(t.Key, newVal);
                }

                return result;
            }

            public static Expression Subtract(Expression exp1, Expression exp2)
            {
                Expression result = new Expression();
                result.ConstantVal = exp1.ConstantVal - exp2.ConstantVal;
                result.Terms = new Dictionary<string, int>(exp1.Terms);
                foreach (var t in exp2.Terms)
                {
                    int newVal = (result.Terms.ContainsKey(t.Key) ? result.Terms[t.Key] : 0) - t.Value;
                    result.AddTerm(t.Key, newVal);
                }

                return result;
            }

            public static Expression Multiply(Expression exp1, Expression exp2)
            {
                Expression result = new Expression();
                result.ConstantVal = exp1.ConstantVal * exp2.ConstantVal;

                if (exp1.ConstantVal != 0)
                {
                    foreach (var t in exp2.Terms)
                    {
                        if (!result.Terms.ContainsKey(t.Key))
                        {
                            result.Terms[t.Key] = 0;
                        }

                        result.Terms[t.Key] += t.Value * exp1.ConstantVal;
                    }
                }

                if (exp2.ConstantVal != 0)
                {
                    foreach (var t in exp1.Terms)
                    {
                        if (!result.Terms.ContainsKey(t.Key))
                        {
                            result.Terms[t.Key] = 0;
                        }

                        result.Terms[t.Key] += t.Value * exp2.ConstantVal;
                    }
                }

                foreach (var t1 in exp1.Terms)
                {
                    foreach (var t2 in exp2.Terms)
                    {
                        var keysList = t1.Key.Split(new char[] { '*' }).Concat(t2.Key.Split(new char[] { '*' }));
                        string newKey = String.Join("*", keysList.OrderBy(v => v));
                        int newVal = (result.Terms.ContainsKey(newKey) ? result.Terms[newKey] : 0) + (t1.Value * t2.Value);
                        result.AddTerm(newKey, newVal);
                    }
                }

                return result;
            }

            public void AddTerm(string newKey, int newVal)
            {
                if (newVal == 0)
                {
                    this.Terms.Remove(newKey);
                }
                else
                {
                    if (!this.Terms.ContainsKey(newKey))
                    {
                        this.Terms.Add(newKey, newVal);
                    }

                    this.Terms[newKey] = newVal;
                }
            }
        }



        public abstract class CalculatorInput
        {
            public enum CalculatorInputType { Operand, Operator, LeftParam, RightParam }
            public CalculatorInputType InputType { get; private set; }
            public CalculatorInput(CalculatorInputType inpType)
            {
                this.InputType = inpType;
            }
        }

        public class OperandInput : CalculatorInput
        {
            public Expression Expression { get; private set; }
            public OperandInput(ExpressionBuilder builder, string token) : base(CalculatorInputType.Operand)
            {
                this.Expression = builder.GetExpression(token);
            }

            public OperandInput(Expression exp) : base(CalculatorInputType.Operand)
            {
                this.Expression = exp;
            }
        }

        public class OperatorInput : CalculatorInput
        {
            public string Operator { get; private set; }
            public OperatorInput(string token) : base(CalculatorInputType.Operator)
            {
                this.Operator = token;
            }
        }

        public class LeftParamInput : CalculatorInput
        {
            public LeftParamInput() : base(CalculatorInputType.LeftParam) { }
        }

        public class RightParamInput : CalculatorInput
        {
            public RightParamInput() : base(CalculatorInputType.RightParam) { }
        }

        public IList<string> BasicCalculatorIV(string expression, string[] evalvars, int[] evalints)
        {
            Dictionary<string, int> tokenVals = new Dictionary<string, int>();
            for (int i = 0; i < evalvars.Length; i++)
            {
                tokenVals.Add(evalvars[i], evalints[i]);
            }

            ExpressionBuilder builder = new ExpressionBuilder(tokenVals);
            expression = expression.Replace("(", " ( ").Replace(")", " ) ");
            string[] split = expression.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<CalculatorInput> input = new List<CalculatorInput>();
            foreach (var s in split)
            {
                if (s == "*" || s == "-" || s == "+")
                {
                    input.Add(new OperatorInput(s));
                }
                else if (s == "(")
                {
                    input.Add(new LeftParamInput());
                }
                else if (s == ")")
                {
                    input.Add(new RightParamInput());
                }
                else
                {
                    input.Add(new OperandInput(builder, s));
                }
            }

            OperandInput result = InfixCalculator(input);
            return result.Expression.ToList();
        }




        private OperandInput InfixCalculator(List<CalculatorInput> input)
        {
            Dictionary<string, int> precedence = new Dictionary<string, int>();
            precedence.Add("+", 1);
            precedence.Add("-", 1);
            precedence.Add("*", 2);
            int preMul = 0;
            Stack<CalculatorInput> vars = new Stack<CalculatorInput>();
            Stack<OperatorInput> ops = new Stack<OperatorInput>();
            Stack<int> pre = new Stack<int>();

            foreach (var inp in input)
            {
                if (inp.InputType == CalculatorInput.CalculatorInputType.Operand || inp.InputType == CalculatorInput.CalculatorInputType.LeftParam)
                {
                    vars.Push(inp);
                    if (inp.InputType == CalculatorInput.CalculatorInputType.LeftParam)
                    {
                        preMul++;
                    }
                }
                else if (inp.InputType == CalculatorInput.CalculatorInputType.Operator)
                {
                    OperatorInput opr = (OperatorInput)inp;
                    while (ops.Any() && pre.Peek() >= 2 * preMul + precedence[opr.Operator])
                    {
                        vars.Push(Evaluate(vars, ops, pre));
                    }

                    ops.Push(opr);
                    pre.Push(2 * preMul + precedence[opr.Operator]);
                }
                else if (inp.InputType == CalculatorInput.CalculatorInputType.RightParam)
                {
                    while (vars.Any())
                    {
                        var result = Evaluate(vars, ops, pre);
                        if (vars.Peek().InputType == CalculatorInput.CalculatorInputType.LeftParam)
                        {
                            // Pop the left param and push the final result.
                            vars.Pop();
                            vars.Push(result);
                            break;
                        }
                        else
                        {
                            vars.Push(result);
                        }
                    }

                    preMul--;
                }
            }

            while (vars.Count > 1)
            {
                vars.Push(Evaluate(vars, ops, pre));
            }

            // There will be only one expression
            return ((OperandInput)vars.Pop());
        }

        private CalculatorInput Evaluate(Stack<CalculatorInput> vars, Stack<OperatorInput> ops, Stack<int> pre)
        {
            OperandInput right = (OperandInput)vars.Pop();
            CalculatorInput leftInput = vars.Peek();
            if (leftInput.InputType == CalculatorInput.CalculatorInputType.LeftParam)
            {
                return right;
            }

            OperandInput left = (OperandInput)vars.Pop();

            OperatorInput opr = ops.Pop();
            pre.Pop();
            Expression result = null;
            if (opr.Operator == "+")
            {
                result = Expression.Add(left.Expression, right.Expression);
            }
            else if (opr.Operator == "-")
            {
                result = Expression.Subtract(left.Expression, right.Expression);
            }
            else
            {
                result = Expression.Multiply(left.Expression, right.Expression);
            }

            return new OperandInput(result);

        }
        public int SlidingPuzzle(int[,] board)
        {
            Dictionary<int, List<int>> travelMap = new Dictionary<int, List<int>>();
            travelMap.Add(0, new List<int> { 1, 3 });
            travelMap.Add(1, new List<int> { 0, 2, 4 });
            travelMap.Add(2, new List<int> { 1, 5 });
            travelMap.Add(3, new List<int> { 0, 4 });
            travelMap.Add(4, new List<int> { 1, 3, 5 });
            travelMap.Add(5, new List<int> { 2, 4 });

            string init = string.Empty;
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    init += board[i, j];

            string target = "123450";
            Queue<string> q = new Queue<string>();
            q.Enqueue(init);
            HashSet<string> visited = new HashSet<string>();
            int res = 0;
            while (q.Count > 0)
            {
                int qCount = q.Count;
                for (int c = 0; c < qCount; c++)
                {
                    string cur = q.Dequeue();
                    if (cur == target) return res;
                    if (!visited.Add(cur)) continue;

                    int zeroIndex = cur.IndexOf('0');

                    foreach (int i in travelMap[zeroIndex])
                    {
                        char[] content = cur.ToCharArray();
                        char tmp = content[zeroIndex];
                        content[zeroIndex] = content[i];
                        content[i] = tmp;
                        string newS = new string(content);
                        if (!visited.Contains(newS))
                            q.Enqueue(newS);
                    }
                }
                res++;
            }

            return -1;
        }

        static int[,] steps = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };
        public int SwimInWater(int[,] grid)
        {
            int n = grid.GetLength(0);
            int[,] max = new int[n,n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++) max[i, j] = int.MaxValue;
            dfs(grid, max, 0, 0, grid[0,0]);
            return max[n - 1,n - 1];
        }

        private void dfs(int[,] grid, int[,] max, int x, int y, int cur)
        {
            int n = grid.GetLength(0);
            if (x < 0 || x >= n || y < 0 || y >= n || Math.Max(cur, grid[x,y]) >= max[x,y])
                return;
            max[x,y] = Math.Max(cur, grid[x,y]);
            for(int i = 0; i < steps.GetLength(0);i++)
            {
                dfs(grid, max, x + steps[i, 0], y + steps[i, 1], max[x, y]);
            }
        }

        public bool ReachingPoints(int sx, int sy, int tx, int ty)
        {
            if (sx > tx || sy > ty) return false;
            if (sx == tx && (ty - sy) % sx == 0) return true;
            if (sy == ty && (tx - sx) % sy == 0) return true;
            return ReachingPoints(sx, sy, tx % ty, ty % tx);
        }

        public int MovesToChessboard(int[,] board)
        {
            int N = board.GetLength(0), rowSum = 0, colSum = 0, rowSwap = 0, colSwap = 0;
            for (int i = 0; i < N; ++i) for (int j = 0; j < N; ++j)
                    if ((board[0,0] ^ board[i,0] ^ board[0,j] ^ board[i,j]) == 1) return -1;
            for (int i = 0; i < N; ++i)
            {
                rowSum += board[0,i];
                colSum += board[i,0];
                if (board[i,0] == i % 2) rowSwap++;
                if (board[0,i] == i % 2) colSwap++;
            }
            if (N / 2 > rowSum || rowSum > (N + 1) / 2) return -1;
            if (N / 2 > colSum || colSum > (N + 1) / 2) return -1;
            if (N % 2 == 1)
            {
                if (colSwap % 2 == 1) colSwap = N - colSwap;
                if (rowSwap % 2 == 1) rowSwap = N - rowSwap;
            }
            else
            {
                colSwap = Math.Min(N - colSwap, colSwap);
                rowSwap = Math.Min(N - rowSwap, rowSwap);
            }
            return (colSwap + rowSwap) / 2;
        }
        int p, q;

        // O(n) for each check.
        bool check(double mid, int[] A, int K)
        {
            int n = A.Length;
            int p1 = 0, q1 = 0;
            int total = 0;

            for (int i = 0, j = 0; i < n; i++)
            {
                for (; j < n; j++)
                { // j will not backtrack.
                    if (i < j && A[i] < A[j] * mid)
                    {
                        if (p1 == 0 || p1 * A[j] < A[i] * q1)
                        {
                            p1 = A[i];
                            q1 = A[j];
                        }
                        break;
                    }
                }
                total += n - j;
            }
            if (total <= K)
            {
                if (p == 0 || p * q1 < p1 * q)
                {
                    p = p1;
                    q = q1;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public int[] KthSmallestPrimeFraction(int[] A, int K)
        {
            p = q = 0;
            double low = 0.0;
            double high = 1.0;
            // Around 30 times of iteration
            while (high - low > 1e-8)
            {
                double mid = (low + high) / 2.0;
                if (check(mid, A, K))
                {
                    low = mid;
                }
                else
                {
                    high = mid;
                }
            }
            return new int[] { p, q };
        }
        public int PreimageSizeFZF(int K)
        {
            if (K < 5)
            {
                return 5;
            }
            int d = 1;
            while (d * 5 + 1 <= K)
            {
                d = d * 5 + 1;
            }
            if (K / d == 5)
            {
                return 0;
            }
            return PreimageSizeFZF(K % d);
        }

        public int PreimageSizeFZF1(int K)
        {
            long l = 5;
            long h = long.MaxValue;
            long middle = 0;
            long zeroes = 0;
            while (l < h)
            {
                middle = l + (h - l) / 2;
                zeroes = GetZeros(middle);
                if (zeroes == K)
                    return 5;
                else if (zeroes < K)
                    l = middle + 1;
                else
                    h = middle - 1;
            }
            return 0;
        }

        private long GetZeros(long num)
        {
            long count = 0;
            for (long i = 5; num / i > 0; i *= 5)
            {
                count += num / i;
            }
            return count;
        }

        public int BestRotation(int[] A)
        {
            int[] count = new int[A.Length + 1];
            int len = A.Length;
            for (int index = 0; index < A.Length; index++)
            {
                int num = A[index];
                if (index < num)
                {
                    int maxLenK = (index + 1) % len;
                    int ori = (index + len - num) % len;
                    count[maxLenK]++;
                    count[ori + 1]--;
                }
                else
                {      // index >= num
                    int ori = (index + len - num) % len;
                    count[0]++;
                    count[ori + 1]--;
                    if (index != len - 1)
                    {
                        count[(index + 1) % len]++;
                        count[len]--;
                    }
                }
            }
            int max = count[0];
            int res = 0;
            for (int i = 1; i < len; i++)
            {
                count[i] = count[i] + count[i - 1];
                if (count[i] > max)
                {
                    max = count[i];
                    res = i;
                }
            }
            return res;
        }

        public int[] HitBricks(int[][] grid, int[][] hits)
        {
            if (hits.GetLength(0) == 0 || hits.GetLength(1) == 0) return null;
            removeHitBrick(grid, hits);
            markRemainBricks(grid);
            return searchFallingBrick(grid, hits);
        }

        private void markRemainBricks(int[][] grid)
        {
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                deepSearch(grid, 0, i);
            }
        }

        private void removeHitBrick(int[][] grid, int[][] hits)
        {
            for (int i = 0; i < hits.GetLength(0); i++)
            {
                grid[hits[i][0]][hits[i][1]] = grid[hits[i][0]][hits[i][1]] - 1;
            }
        }

        private int[] searchFallingBrick(int[][] grid, int[][] hits)
        {
            int[] result = new int[hits.GetLength(0)];
            for (int i = hits.GetLength(0) - 1; i >= 0; i--)
            {
                if (grid[hits[i][0]][hits[i][1]] == 0)
                {
                    grid[hits[i][0]][hits[i][1]] = 1;
                    if (isConnectToTop(grid, hits[i][0], hits[i][1]))
                    {
                        result[i] = deepSearch(grid, hits[i][0], hits[i][1]) - 1;
                    }
                    else
                    {
                        result[i] = 0;
                    }
                }
            }
            return result;
        }

        private bool isConnectToTop(int[][] grid, int i, int j)
        {
            if (i == 0) return true;

            if (i - 1 >= 0 && grid[i - 1][j] == 2)
            {
                return true;
            }
            if (i + 1 < grid.GetLength(0) && grid[i + 1][j] == 2)
            {
                return true;
            }
            if (j - 1 >= 0 && grid[i][j - 1] == 2)
            {
                return true;
            }
            if (j + 1 < grid.GetLength(1) && grid[i][j + 1] == 2)
            {
                return true;
            }
            return false;
        }

        private int deepSearch(int[][] data, int row, int column)
        {
            int arrayRow = data.GetLength(0);
            int arrayLine = data.GetLength(1);
            int effectBricks = 0;
            if (row < 0 || row >= arrayRow) return effectBricks;
            if (column < 0 || column >= arrayLine) return effectBricks;
            if (data[row][column] == 1)
            {
                data[row][column] = 2;
                effectBricks = 1;
                effectBricks += deepSearch(data, row + 1, column);
                effectBricks += deepSearch(data, row - 1, column);
                effectBricks += deepSearch(data, row, column + 1);
                effectBricks += deepSearch(data, row, column - 1);
            }
            return effectBricks;
        }


        public bool SplitArraySameAverage(int[] A)
        {
            int n = A.Length, s = A.Sum();
            for (int i = 1; i <= n / 2; ++i) if (s * i % n == 0 && find(A, s * i / n, i, 0)) return true;
            return false;
        }

        public bool find(int[] A, int target, int k, int i)
        {
            if (k == 0) return target == 0;
            if (k + i > A.Length) return false;
            return find(A, target - A[i], k - 1, i + 1) || find(A, target, k, i + 1);
        }

        int[] dp = new int[10001];
        public int Racecar(int target)
        {
            if (dp[target] > 0) return dp[target];
            int n = (int)(Math.Log(target) / Math.Log(2)) + 1;
            if (1 << n == target + 1) dp[target] = n;
            else
            {
                dp[target] = Racecar((1 << n) - 1 - target) + n + 1;
                for (int m = 0; m < n - 1; ++m)
                    dp[target] = Math.Min(dp[target], Racecar(target - (1 << (n - 1)) + (1 << m)) + n + m + 1);
            }
            return dp[target];
        }

        public int LargestIsland(int[][] grid)
        {
            int rows = grid.Length;
            if (rows == 0)
            {
                return 0;
            }

            int cols = grid[0].Length;
            UnionFind u = new UnionFind(rows * cols);

            // Top, left, down, right
            int[] dx = new int[] { -1, 0, 1, 0 };
            int[] dy = new int[] { 0, -1, 0, 1 };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        int key1 = i * cols + j;
                        int[] up = new int[] { i - 1, j };
                        int[] left = new int[] { i, j - 1 };
                        List<int[]> neighbors = new List<int[]> { up, left };
                        foreach (var nei in neighbors)
                        {
                            if (nei[0] >= 0 && nei[0] < rows && nei[1] >= 0 && nei[1] < cols && grid[nei[0]][nei[1]] == 1)
                            {
                                int key2 = nei[0] * cols + nei[1];
                                u.Union(key1, key2);
                            }
                        }
                    }
                }
            }


            int maxIsland = u.MaxSize();
            // Now all the union trees have a size and parent;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        // Avoid merging the same island twice.
                        HashSet<int> added = new HashSet<int>();
                        int size = 1;
                        for (int di = 0; di < 4; di++)
                        {
                            int nei = i + dx[di];
                            int nej = j + dy[di];
                            if (nei >= 0 && nei < rows && nej >= 0 && nej < cols && grid[nei][nej] == 1)
                            {
                                int key = nei * cols + nej;
                                int pn = u.GetParent(key);
                                if (!added.Contains(pn))
                                {
                                    size += u.GetSize(pn);
                                    added.Add(pn);
                                }
                            }
                        }

                        maxIsland = Math.Max(size, maxIsland);
                    }
                }
            }

            return maxIsland;

        }

        public class UnionFind
        {
            public int[] parents;
            public int[] size;
            public int[] rank;

            public UnionFind(int nodes)
            {
                this.parents = new int[nodes];
                this.size = new int[nodes];
                this.rank = new int[nodes];
                for (int i = 0; i < nodes; i++)
                {
                    this.parents[i] = i;
                    this.size[i] = 1;
                }
            }

            public int GetParent(int n)
            {
                if (n != this.parents[n])
                {
                    this.parents[n] = GetParent(this.parents[n]);
                }

                return this.parents[n];
            }

            public int GetSize(int n)
            {
                return this.size[n];
            }

            public int MaxSize()
            {
                return this.size.Max();
            }

            public void Union(int i, int j)
            {
                int pi = this.GetParent(i);
                int pj = this.GetParent(j);
                if (pi == pj)
                {
                    return;
                }
                else
                {
                    // Use the higher rank as parent;
                    if (rank[pi] > rank[pj])
                    {
                        parents[pj] = pi;
                        size[pi] += size[pj];
                    }
                    else if (rank[pj] > rank[pi])
                    {
                        parents[pi] = pj;
                        size[pj] += size[pi];
                    }
                    else
                    {
                        parents[pj] = pi;
                        size[pi] += size[pj];
                        rank[pi]++;
                    }
                }
            }
        }

        public int UniqueLetterString(string S)
        {

            if (string.IsNullOrEmpty(S)) return 0;
            int MOD = 1000000007;
            long res = 0;
            for (int i = 0; i < 26; i++)
            {
                var cur = (char)(i + 'A');
                int last_index = -1;
                int first_index = -1;
                int second_index = -1;

                first_index = S.IndexOf(cur);

                if (first_index == -1) continue;

                while (true)
                {
                    second_index = S.IndexOf(cur, first_index + 1);
                    int left = first_index - (last_index + 1);
                    int right = -1;

                    if (second_index == -1)
                        right = (S.Length - 1) - (first_index);
                    else
                        right = second_index - (first_index + 1);

                    res += left;
                    res += right;
                    res++;
                    res += (left * right);
                    res %= MOD;
                    if (second_index == -1) break;

                    last_index = first_index;
                    first_index = second_index;

                }
            }

            return (int)res;
        }

        public int[] SumOfDistancesInTree(int N, int[][] edges)
        {
            // Initialize the graph (note that it should be an undirected acyclic graph)
            List<Node> tr = new List<Node>(N);
            for (int i = 0; i < N; ++i)
            {
                tr.Add(new Node(i));
            }
            for (int i = 0; i < N - 1; ++i)
            {
                tr[edges[i][0]].addNeighbour(tr[edges[i][1]]);
            }

            // First pass: 
            // 1) Turn undirected acyclic graph into a tree based on DFS traversal, with the root in the first node 
            // 2) Compute the number of children and the sum of distances to children under each node
            int[] sumChildren = new int[N];
            int[] numChildren = new int[N];
            int[] dist = new int[N];
            bool[] vis = new bool[N];
            traverse1(tr[0], sumChildren, numChildren, vis, N);

            // Second pass: compute sum of distances for each node based on previously computed results
            vis = new bool[N];
            traverse2(tr[0], dist, sumChildren, numChildren, vis, N);

            return dist;
        }


        static int traverse1(Node node, int[] sumChildren, int[] numChildren, bool[] vis, int N)
        {
            // The "visited" lookup accounts for cycles
            if (node == null || vis[node.id]) return 0;
            vis[node.id] = true;

            int sumOfDistances = 0;
            foreach (Node ch in node.neighbours)
            {
                if (vis[ch.id]) continue;
                // Set parent-child relations based on the traversal
                ch.parent = node;
                sumOfDistances += traverse1(ch, sumChildren, numChildren, vis, N);
                numChildren[node.id] += numChildren[ch.id] + 1;
            }

            sumChildren[node.id] = sumOfDistances + numChildren[node.id];

            return sumChildren[node.id];
        }

        public void traverse2(Node node, int[] dist, int[] sumChildren, int[] numChildren, bool[] vis, int N)
        {
            if (node == null || vis[node.id]) return;
            vis[node.id] = true;

            if (node.parent == null)
            { // Root node
                dist[node.id] = sumChildren[node.id];
            }
            else
            { // Non-root nodes
                int sumOfDistancesToChildNodes = sumChildren[node.id];
                int numberOfNonChildNodes = N - numChildren[node.id] - 1;
                int sumOfDistancesForParentWithoutThisBranch = (dist[node.parent.id] - sumChildren[node.id] - numChildren[node.id] - 1);
                int sumOfDistancesToOtherNodes = sumOfDistancesForParentWithoutThisBranch + numberOfNonChildNodes;
                dist[node.id] = sumOfDistancesToChildNodes + sumOfDistancesToOtherNodes;
            }
            // Recurse further into children
            foreach (Node ch in node.neighbours)
            {
                if (vis[ch.id]) continue;
                traverse2(ch, dist, sumChildren, numChildren, vis, N);
            }
        }

        int Match(string w1, string w2, int res = 0)
        {
            for (int i = 0; i < w1.Length; ++i) if (w1[i] == w2[i]) ++res;
            return res;
        }
        private string bestCandidate(List<string> remaining, List<List<int>> probs)
        {
            int max_score = 0;
            string best = string.Empty;
            foreach (var item in remaining)
            {
                int score = 0;
                for (int i = 0; i < 6 && score >= 0; ++i) score += probs[i][item[i] - 'a'];
                if (score > max_score)
                {
                    max_score = score;
                    best = item;
                }
            }
            return best;
        }


        public int RectangleArea(int[][] rectangles)
        {

            int mod = (int)Math.Pow(10, 9) + 7;
            long res = 0;
            List<int[]> recList = new List<int[]>();
            foreach (int[] rec in rectangles)
                addRectangle(recList, rec, 0);

            foreach (int[] rec in recList)
                res = (res + ((long)(rec[2] - rec[0]) * (long)(rec[3] - rec[1]))) % mod;

            return (int)res % mod;
        }

        // Add new rectangle to the list. In case of overlap break up new rectangle into 
        // non-overlapping rectangles. Compare the new rectanlges with the rest of the list.
        public void addRectangle(List<int[]> recList, int[] curRec, int start)
        {
            if (start >= recList.Count)
            {
                recList.Add(curRec);
                return;
            }

            int[] r = recList[start];

            // No overlap
            if (curRec[2] <= r[0] || curRec[3] <= r[1] || curRec[0] >= r[2] || curRec[1] >= r[3])
            {
                addRectangle(recList, curRec, start + 1);
                return;
            }

            if (curRec[0] < r[0])
                addRectangle(recList, new int[] { curRec[0], curRec[1], r[0], curRec[3] }, start + 1);

            if (curRec[2] > r[2])
                addRectangle(recList, new int[] { r[2], curRec[1], curRec[2], curRec[3] }, start + 1);

            if (curRec[1] < r[1])
                addRectangle(recList, new int[] { Math.Max(r[0], curRec[0]), curRec[1], Math.Min(r[2], curRec[2]), r[1] }, start + 1);

            if (curRec[3] > r[3])
                addRectangle(recList, new int[] { Math.Max(r[0], curRec[0]), r[3], Math.Min(r[2], curRec[2]), curRec[3] }, start + 1);
        }

        public int KSimilarity(string A, string B)
        {
            if (A.Equals(B))
            {
                return 0;
            }
            char[] a = A.ToCharArray();
            char[] b = B.ToCharArray();
            int cnt = preProcess(a, b);
            cnt += dfs(a, b, 0);
            return cnt;
        }

        public int dfs(char[] a, char[] b, int start)
        {
            if (start == a.Length)
            {
                return 0;
            }
            if (a[start] == b[start])
            {
                return dfs(a, b, start + 1);
            }
            int min = int.MaxValue;
            for (int i = start + 1; i < a.Length; i++)
            {
                if (a[i] == b[start] && a[i] != b[i])
                {
                    swap(a, start, i);
                    min = Math.Min(min, 1 + dfs(a, b, start + 1));
                    swap(a, start, i);
                    if (a[start] == b[i])
                    {
                        return min;
                    }
                }
            }
            return min;
        }

        public int preProcess(char[] a, char[] b)
        {
            int cnt = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                {
                    continue;
                }
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] == b[j] && a[j] == b[i])
                    {
                        swap(a, i, j);
                        cnt++;
                        break;
                    }
                }
            }
            return cnt;
        }

        public void swap(char[] chars, int p1, int p2)
        {
            char temp = chars[p1];
            chars[p1] = chars[p2];
            chars[p2] = temp;
        }

        public int NthMagicalNumber(int N, int A, int B)
        {
            long a = A, b = B, tmp, l = 2, r = (long)1e14, mod = (long)1e9 + 7;
            while (b > 0)
            {
                tmp = a;
                a = b;
                b = tmp % b;
            }
            while (l < r)
            {
                long m = (l + r) / 2;
                if (m / A + m / B - m / (A * B / a) < N) l = m + 1;
                else r = m;
            }
            return (int)(l % mod);
        }


        public int SuperEggDrop(int K, int N)
        {
            int[,] dp = new int[N + 1,K + 1];
            int m = 0;
            while (dp[m,K] < N)
            {
                ++m;
                for (int k = 1; k <= K; ++k)
                    dp[m,k] = dp[m - 1,k - 1] + dp[m - 1,k] + 1;
            }
            return m;
        }


        public int SumSubseqWidths(int[] A)
        {
            Array.Sort(A);
            long c = 1, res = 0, mod = (long)1e9 + 7;
            for (int i = 0; i < A.Length; ++i, c = (c << 1) % mod)
                res = (res + A[i] * c - A[A.Length - i - 1] * c) % mod;
            return (int)((res + mod) % mod);

        }

        public string OrderlyQueue(string S, int K)
        {
            if (K > 1)
            {
                char[] S2 = S.ToCharArray();
                Array.Sort(S2);
                return new String(S2);
            }
            String res = S;
            for (int i = 1; i < S.Length; i++)
            {
                String tmp = S.Substring(i) + S.Substring(0, i);
                if (res.CompareTo(tmp) > 0) res = tmp;
            }
            return res;
        }

        public bool XorGame(int[] nums)
        {
            int xor = 0;
            foreach (int i in nums) xor ^= i;
            return xor == 0 || nums.Length % 2 == 0;
        }

        public int NumBusesToDestination(int[][] routes, int S, int T)
        {
            if (S == T) return 0;
            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
            Queue<int> queue = new Queue<int>();
            HashSet<int> visited = new HashSet<int>();
            for (int i = 0; i < routes.Length; ++i)
            {
                foreach (int j in routes[i])
                {
                    if (!map.ContainsKey(j)) map[j] = new HashSet<int>();
                    map[j].Add(i);
                }
            }
            foreach (int next in map[S])
            {
                visited.Add(next);
                queue.Enqueue(next);
            }
            int res = 1;
            while (queue.Count != 0)
            {
                Queue<int> tmp = new Queue<int>();
                while (queue.Count != 0)
                {
                    int cur = queue.Dequeue();
                    foreach (int c in routes[cur])
                    {
                        if (c == T) return res;
                        foreach (int next in map[c])
                        {
                            if (!visited.Contains(next))
                            {
                                tmp.Enqueue(next);
                                visited.Add(next);
                            }
                        }
                    }
                }
                ++res;
                queue = tmp;
            }
            return -1;
        }

        public int NumSimilarGroups1(string[] A)
        {
            if (A.Length < 2) return A.Length;
            int res = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == null) continue;
                String str = A[i];
                A[i] = null;
                res++;
                dfs(A, str);
            }
            return res;
        }
        public void dfs(String[] arr, String str)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null) continue;
                if (helper(str, arr[i]))
                {// both string str and arr[i] belong in same group
                    String s = arr[i];
                    arr[i] = null;
                    dfs(arr, s);
                }
            }
        }
        public bool helper(String s, String t)
        {
            int res = 0, i = 0;
            while (res <= 2 && i < s.Length)
            {
                if (s[i] != t[i]) res++;
                i++;
            }
            return res == 2;
        }

        private bool similar(string a, string b)
        {

            int s = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    s++;
                    if (s > 2)
                        return false;
                }
            }

            return true;
        }

        int N;
        int[] groups;

        public int NumSimilarGroups(string[] A)
        {

            N = A.Length;

            groups = new int[N];

            for (int i = 0; i < N; i++)
            {
                groups[i] = i;
            }

            for (int i = 0; i < N - 1; i++)
            {
                var gi = groups[i];
                for (int k = i + 1; k < N; k++)
                {
                    if (similar(A[i], A[k]))
                    {
                        var gk = groups[k];
                        for (int j = 0; j < N; j++)
                        {
                            if (groups[j] == gk)
                            {
                                groups[j] = gi;
                            }
                        }

                    }


                }
            }

            return groups.Distinct().Count();

        }

        public int AtMostNGivenDigitSet(string[] D, int N)
        {
            int result = 0;
            for (int i = 1; i <= N.ToString().Length; i++)
            {
                result += helper(D, i, N.ToString());
            }
            return result;
        }

        //exactly N digit
        public int helper(String[] D, int K, String smax)
        {
            if (smax.Equals("0"))
            {
                return 0;
            }
            // String smax = Integer.toString(max);
            if (smax.Length > K)
            {
                return (int)Math.Pow(D.Length, K);
            }
            int count = 0;
            for (int i = 0; i < D.Length; i++)
            {
                int char0 = int.Parse(smax.Substring(0, 1));
                if (int.Parse(D[i]) < char0)
                {
                    count += helper(D, K - 1, smax);
                }
                if (int.Parse(D[i]) == char0)
                {
                    if (smax.Length > 1)
                    {
                        int charRem = int.Parse(smax.Substring(1, 2)) == 0 ? 0 : int.Parse(smax.Substring(1));
                        count += helper(D, K - 1, charRem.ToString());
                    }
                    else
                    {
                        count++;
                    }

                }
            }
            return count;
        }


        public int NumPermsDISequence(string S)
        {
            int n = S.Length, mod = (int)1e9 + 7;
            int[,] dp = new int[n + 1,n + 1];
            for (int j = 0; j <= n; j++) dp[0,j] = 1;
            for (int i = 0; i < n; i++)
                if (S[i] == 'I')
                    for (int j = 0, cur = 0; j < n - i; j++)
                        dp[i + 1,j] = cur = (cur + dp[i,j]) % mod;
                else
                    for (int j = n - i - 1, cur = 0; j >= 0; j--)
                        dp[i + 1,j] = cur = (cur + dp[i,j + 1]) % mod;
            return dp[n,0];
        }

        public int SuperpalindromesInRange(string L, string R)
        {
            long l = long.Parse(L), r = long.Parse(R);
            int result = 0;
            for (long i = (long)Math.Sqrt(l); i * i <= r;)
            {
                long p = nextP(i);
                if (p * p <= r && isP(p * p))
                {
                    result++;
                }
                i = p + 1;
            }
            return result;
        }

        private long nextP(long l)
        {
            String s = "" + l;
            int len = s.Length;
            List<long> cands = new List<long>();
            cands.Add((long)Math.Pow(10, len) - 1);
            String half = s.Substring(0, (len + 1) / 2);
            String nextHalf = "" + (long.Parse(half) + 1);
            String reverse = new StringBuilder(half.Substring(0, len / 2)).ToString();
            reverse = reverse.Reverse().ToString();
            String nextReverse = new StringBuilder(nextHalf.Substring(0, len / 2)).ToString();
            nextReverse = nextReverse.Reverse().ToString();
            cands.Add(long.Parse(half + reverse));
            cands.Add(long.Parse(nextHalf + nextReverse));
            long result = long.MaxValue;
            foreach (long i in cands)
            {
                if (i >= l)
                {
                    result = Math.Min(result, i);
                }
            }
            return result;
        }

        private bool isP(long l)
        {
            String s = "" + l;
            int i = 0, j = s.Length - 1;
            while (i < j)
            {
                if (s[i++] != s[j--])
                {
                    return false;
                }
            }
            return true;
        }

        int[][] G;
        int[,,] dp1;

        public int CatMouseGame(int[][] graph)
        {
            G = graph;
            dp1 = new int[graph.Length,graph.Length,3];

            int res = helper(new int[] { 1, 2, 0 });
            if (res == 1)
                return 2;
            else if (res == 2)
                return 0;
            return 1;
        }

        public int helper(int[] status)
        {

            int mouse = status[0], cat = status[1], flag = status[2];
            // System.out.print(mouse + " " + cat + " " + flag + " ");
            // System.out.println();
            if (dp1[mouse,cat,flag] > 0)
                return dp1[mouse,cat,flag];
            dp1[mouse,cat,flag] = 2;
            if (mouse == 0)
                return 3;
            if (mouse == cat)
                return 1;
            if (flag == 0)
            {
                int max = 0;
                foreach (int next in G[mouse])
                {
                    if (next == 0)
                    {
                        dp1[mouse,cat,flag] = 3;
                        return 3;
                    }

                }
                foreach (int next in G[mouse])
                {
                    int cur = helper(new int[] { next, cat, 1 });
                    max = Math.Max(max, cur);
                    if (max == 3)
                    {
                        dp1[mouse,cat,flag] = max;
                        return max;
                    }

                }
                dp1[mouse,cat,flag] = max;
                return max;
            }
            else
            {
                int min = 4;
                foreach (int next in G[cat])
                {
                    if (next == mouse)
                    {
                        dp1[mouse,cat,flag] = 1;
                        return 1;
                    }
                }
                foreach (int next in G[cat])
                {
                    if (next != 0)
                    {
                        int cur = helper(new int[] { mouse, next, 0 });
                        min = Math.Min(min, cur);
                    }

                    if (min == 1)
                    {
                        dp1[mouse,cat,flag] = 1;
                        return 1;
                    }

                }
                dp1[mouse,cat,flag] = min;
                return min;
            }
        }

        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            var result = new List<IList<string>>();
            if (string.IsNullOrEmpty(beginWord) || string.IsNullOrEmpty(endWord) || wordList == null || !wordList.Any())
                return result;
            var neighbours = new Dictionary<string, List<string>>();
            var set = new HashSet<string>(wordList);
            var distance = new Dictionary<string, int>();
            distance[beginWord] = 0;
            set.Add(beginWord);
            Bfs(beginWord, endWord, neighbours, distance, set);
            Dfs(beginWord, endWord, neighbours, distance, result, new List<string>());
            return result;
        }

        private void Bfs(string begin, string end, Dictionary<string, List<string>> neighbours, Dictionary<string, int> distance, HashSet<string> set)
        {
            var queue = new Queue<string>();
            var isEnd = false;
            queue.Enqueue(begin);
            while (queue.Any() && !isEnd)
            {
                var t = new Queue<string>();
                while (queue.Any())
                {
                    var node = queue.Dequeue();
                    var newNeighbours = GetNeighbours(node, set);
                    foreach (var newWord in newNeighbours)
                    {
                        if (!neighbours.ContainsKey(node))
                        {
                            neighbours[node] = new List<string>();
                        }
                        neighbours[node].Add(newWord);
                        if (!distance.ContainsKey(newWord))
                        {
                            distance[newWord] = distance[node] + 1;
                            if (newWord == end)
                            {
                                isEnd = true;
                                break;
                            }
                            else
                            {
                                t.Enqueue(newWord);
                            }
                        }
                    }
                }
                queue = t;
            }
        }

        private void Dfs(string start, string end, Dictionary<string, List<string>> neighbours, Dictionary<string, int> distance, IList<IList<string>> result, IList<string> temp)
        {
            temp.Add(start);
            if (start == end)
            {
                result.Add(new List<string>(temp));
            }
            else
            {
                if (neighbours.ContainsKey(start))
                {
                    foreach (var newWord in neighbours[start])
                    {
                        if (distance[newWord] == distance[start] + 1)
                        {
                            Dfs(newWord, end, neighbours, distance, result, temp);
                        }
                    }
                }

            }

            temp.RemoveAt(temp.Count - 1);
        }


        private IList<string> GetNeighbours(string word, HashSet<string> set)
        {
            var result = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                var tempWord = word.ToCharArray();
                var cTemp = tempWord[i];
                for (char c = 'a'; c <= 'z'; c++)
                {
                    if (c != cTemp)
                    {
                        tempWord[i] = c;
                        var newString = new string(tempWord);
                        if (set.Contains(newString))
                        {
                            result.Add(newString);
                        }
                        tempWord[i] = cTemp;
                    }

                }
            }
            return result;
        }

        public IList<int[]> GetSkyline(int[,] buildings)
        {
            IList<int[]> result = new List<int[]>();
            int[] x2Buildings = new int[buildings.GetLength(0)], heights = new int[buildings.GetLength(0)];
            for (int i = 0; i < x2Buildings.Length; i++)
            { x2Buildings[i] = buildings[i, 1]; heights[i] = buildings[i, 2]; }
            Array.Sort(x2Buildings, heights); //Sort x2 and height seqences
            int[,] xAll = new int[buildings.GetLength(0) * 2, 3]; //0: x, 1: height, 2: left/right
            for (int i = 0, j = 0; i < buildings.GetLength(0) || j < x2Buildings.Length;)
            { // Merging Sort all edges
                int x1 = i < buildings.GetLength(0) ? buildings[i, 0] : int.MaxValue;
                int x2 = j < x2Buildings.Length ? x2Buildings[j] : int.MaxValue;
                if (j == x2Buildings.Length || i < buildings.GetLength(0) && x1 <= x2)
                {
                    xAll[i + j, 0] = buildings[i, 0];
                    xAll[i + j, 1] = buildings[i, 2];
                    xAll[i + j, 2] = 0;
                    i++;
                }
                else
                {
                    xAll[i + j, 0] = x2Buildings[j];
                    xAll[i + j, 1] = heights[j];
                    xAll[i + j, 2] = 1;
                    j++;
                }
            }
            Dictionary<int, int> curHeights = new Dictionary<int, int>();
            SortedSet<int> sH = new SortedSet<int>();
            for (int i = 0; i < xAll.GetLength(0); i++)
            {
                if (xAll[i, 2] == 0)
                {
                    curHeights[xAll[i, 1]] = curHeights.ContainsKey(xAll[i, 1]) ? curHeights[xAll[i, 1]] + 1 : 1;
                    sH.Add(xAll[i, 1]);
                }
                else
                {
                    if (curHeights[xAll[i, 1]] > 1) curHeights[xAll[i, 1]]--;
                    else
                    {
                        curHeights.Remove(xAll[i, 1]);
                        sH.Remove(xAll[i, 1]);
                    }
                }
                int curMaxHeight = curHeights.Count == 0 ? 0 : sH.Max;
                if (result.Count > 0 && result[result.Count - 1][1] == curMaxHeight) continue;
                else if (result.Count > 0 && result[result.Count - 1][0] == xAll[i, 0])
                    result[result.Count - 1][1] = curMaxHeight;
                else result.Add(new int[] { xAll[i, 0], curMaxHeight });
            }
            return result;
        }

        public int Calculate(string s)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < s.Length; i++)
            {
                int ch = s[i], tmp = 0;
                if (ch == '(' || ch == '+' || ch == '-') stack.Push(ch);
                else if (ch == ')')
                {
                    tmp = stack.Pop();
                    stack.Pop();
                    stack.Push(stack.Count == 0 || stack.Peek() == '(' ? tmp : (stack.Pop() == '+' ? 1 : -1) * tmp + stack.Pop());
                }
                else if (ch >= '0' && ch <= '9')
                {
                    while (i < s.Length && s[i] >= '0' && s[i] <= '9')
                        tmp = (s[i++] - '0') + 10 * tmp;
                    i--;
                    stack.Push(stack.Count == 0 || stack.Peek() == '(' ? tmp : (stack.Pop() == '+' ? 1 : -1) * tmp + stack.Pop());
                }
            }
            return stack.Pop();
        }

        public IList<string> RemoveInvalidParentheses(string s)
        {
            List<String> ans = new List<string>();
            remove(s, ans, 0, 0, new char[] { '(', ')' });
            return ans;
        }

        public void remove(String s, List<String> ans, int last_i, int last_j, char[] par)
        {
            for (int stack = 0, i = last_i; i < s.Length; ++i)
            {
                if (s[i] == par[0]) stack++;
                if (s[i] == par[1]) stack--;
                if (stack >= 0) continue;
                for (int j = last_j; j <= i; ++j)
                    if (s[j] == par[1] && (j == last_j || s[j - 1] != par[1]))
                        remove(s.Substring(0, j) + s.Substring(j + 1, s.Length-j-1), ans, i, j, par);
                return;
            }
            String reversed = new StringBuilder(s).ToString();
            reversed = reversed.Reverse().ToString();
            if (par[0] == '(') // finished left to right
                remove(reversed, ans, 0, 0, new char[] { ')', '(' });
            else // finished right to left
                ans.Add(reversed);
        }

        public int MaxCoins(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int[,] dp = new int[nums.Length,nums.Length];
            for (int len = 1; len <= nums.Length; len++)
            {
                for (int start = 0; start <= nums.Length - len; start++)
                {
                    int end = start + len - 1;
                    for (int i = start; i <= end; i++)
                    {
                        int coins = nums[i] * getValue(nums, start - 1) * getValue(nums, end + 1);
                        coins += i != start ? dp[start,i - 1] : 0; // If not first one, we can add subrange on its left.
                        coins += i != end ? dp[i + 1,end] : 0; // If not last one, we can add subrange on its right
                        dp[start,end] = Math.Max(dp[start,end], coins);
                    }
                }
            }
            return dp[0,nums.Length - 1];
        }

        private int getValue(int[] nums, int i)
        { // Deal with num[-1] and num[num.length]
            if (i < 0 || i >= nums.Length)
            {
                return 1;
            }
            return nums[i];
        }

        class Node1
        {
            public Node1 left;
            public Node1 right;
            public int Num = 0;
            public int Count = 0;
            public int m = 0;
        }
        public IList<int> CountSmaller(int[] nums)
        {
            int[] count = new int[nums.Length];
            Node1 root = null;

            for (int i = nums.Length - 1; i > -1; i--)
            {
                int c = 0;
                if (root == null)
                {
                    root = new Node1();
                    root.Num = nums[i];
                }
                else
                {
                    Node1 n = root;
                    Node1 r = root;
                    bool skip = false;
                    do
                    {
                        n = r;

                        if (nums[i] == r.Num)
                        {
                            skip = true;
                            r.m++;
                            c += r.Count;
                            break;
                        }
                        if (nums[i] < r.Num)
                        {
                            r = r.right;
                            n.Count++;
                        }
                        else
                        {
                            c += n.Count + 1 + n.m;
                            r = r.left;
                        }
                    } while (r != null);

                    if (!skip)
                        if (nums[i] < n.Num)
                        {
                            n.right = new Node1();
                            n.right.Num = nums[i];
                        }
                        else
                        {
                            n.left = new Node1();
                            n.left.Num = nums[i];
                        }
                }

                count[i] = c;

            }

            return count.ToList<int>();
        }

        public string RemoveDuplicateLetters(string s)
        {
            Stack<int> st = new Stack<int>(), st2 = new Stack<int>();
            bool[] used = new bool[26];
            int[] count = new int[26];

            for (int i = 0; i < s.Length; i++) count[s[i] - 'a']++;
            for (int i = 0; i < s.Length; i++)
            {
                int c = s[i] - 'a';
                if (used[c]) { count[c]--; continue; }

                while (st.Count > 0 && st.Peek() >= c && count[st.Peek()] > 0) used[st.Pop()] = false;

                st.Push(c);
                count[c]--;
                used[c] = true;
            }

            while (st.Count > 0) st2.Push(st.Pop());

            StringBuilder sb = new StringBuilder();
            while (st2.Count > 0) sb.Append((char)(st2.Pop() + 'a'));

            return sb.ToString();
        }

        public int StrongPasswordChecker(string s)
        {

            if (s.Length < 2) return 6 - s.Length;

            //Initialize the states, including current ending character(end), existence of lowercase letter(lower), uppercase letter(upper), digit(digit) and number of replicates for ending character(end_rep)
            char end = s[0];
            bool upper = end >= 'A' && end <= 'Z', lower = end >= 'a' && end <= 'z', digit = end >= '0' && end <= '9';

            //Also initialize the number of modification for repeated characters, total number needed for eliminate all consequnce 3 same character by replacement(change), and potential maximun operation of deleting characters(delete). Note delete[0] means maximum number of reduce 1 replacement operation by 1 deletion operation, delete[1] means maximun number of reduce 1 replacement by 2 deletion operation, delete[2] is no use here. 
            int end_rep = 1, change = 0;
            int[] delete = new int[3];

            for (int i = 1; i < s.Length; ++i)
            {
                if (s[i] == end) ++end_rep;
                else
                {
                    change += end_rep / 3;
                    if (end_rep / 3 > 0) ++delete[end_rep % 3];
                    //updating the states
                    end = s[i];
                    upper = upper || end >= 'A' && end <= 'Z';
                    lower = lower || end >= 'a' && end <= 'z';
                    digit = digit || end >= '0' && end <= '9';
                    end_rep = 1;
                }
            }
            change += end_rep / 3;
            if (end_rep / 3 > 0) ++delete[end_rep % 3];

            //The number of replcement needed for missing of specific character(lower/upper/digit)
            int check_req = (upper ? 0 : 1) + (lower ? 0 : 1) + (digit ? 0 : 1);

            if (s.Length > 20)
            {
                int del = s.Length - 20;

                //Reduce the number of replacement operation by deletion
                if (del <= delete[0]) change -= del;
                else if (del - delete[0] <= 2 * delete[1]) change -= delete[0] + (del - delete[0]) / 2;
                else change -= delete[0] + delete[1] + (del - delete[0] - 2 * delete[1]) / 3;

                return del + Math.Max(check_req, change);
            }
            else return Math.Max(6 - s.Length, Math.Max(check_req, change));
        }

        public IList<int> LargestDivisibleSubset(int[] nums)
        {
            if (nums.Length == 0) return new List<int>();
            var list = new LinkedList<int>();

            Array.Sort(nums);
            var depths = new int[nums.Length];
            int maxDepth = 0, maxI = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                var max = -1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] % nums[j] == 0)
                        max = Math.Max(max, depths[j]);
                }
                depths[i] = ++max;
                if (max > maxDepth)
                {
                    maxDepth = max;
                    maxI = i;
                }
            }

            list.AddFirst(nums[maxI]);
            for (int i = maxI - 1; i > -1; i--)
            {
                if (nums[maxI] % nums[i] != 0 || depths[i] + 1 != maxDepth)
                    continue;

                list.AddFirst(nums[i]);
                maxDepth--;
                maxI = i;
            }
            return list.ToList();
        }

        public int SuperPow(int a, int[] b)
        {
            int m = a % 1337;
            int r = 1;
            for (int i = b.Length - 1; i > -1; i--)
            {
                r = GetMultMod(GetMod(m, b[i]), r);
                m = GetMod(m, 10);
            }
            return r;
        }

        static int GetMod(int m, int e)
        {
            int r = 1;
            while (e > 0)
            {
                if (e % 2 == 1)
                    r = GetMultMod(r, m);
                m = GetMultMod(m, m);
                e >>= 1;
            }
            return r;
        }

        static int GetMultMod(int a, int b)
        {
            return a * b % 1337;
        }

        public int GetMoneyAmount(int n)
        {
            if (n == 1)
            {
                return 0;
            }
            int[,] dp = new int[n + 1,n + 1];
            for (int jminusi = 1; jminusi < n; jminusi++)
            {
                for (int i = 0; i + jminusi <= n; i++)
                {
                    int j = i + jminusi;
                    dp[i,j] = int.MaxValue;
                    for (int k = i; k <= j; k++)
                    {
                        dp[i,j] = Math.Min(dp[i,j],
                                            k + Math.Max(k - 1 >= i ? dp[i,k - 1] : 0,
                                                         j >= k + 1 ? dp[k + 1,j] : 0));
                    }
                }
            }
            return dp[1,n];
        }

        public int WiggleMaxLength(int[] nums)
        {
            if (nums.Length < 2)
                return nums.Length;

            int n = nums.Length;
            int[] dp = new int[n];

            dp[0] = 1;
            dp[1] = (nums[0] == nums[1]) ? 1 : 2;

            int maxCount = Math.Max(dp[0], dp[1]);

            int flag = getFlag(nums[1], nums[0]);

            for (int i = 2; i < n; i++)
            {
                int f = getFlag(nums[i], nums[i - 1]);

                if (f == 0 || f == flag)
                {
                    dp[i] = dp[i - 1];
                    f = flag;
                }
                else
                {
                    dp[i] = dp[i - 1] + 1;
                }
                maxCount = Math.Max(maxCount, dp[i]);
                flag = f;
            }

            return maxCount;
        }

        int getFlag(int first, int second)
        {
            if (first > second) return 1;
            if (first < second) return -1;
            return 0;
        }
        public int LengthLongestPath(string input)
        {
            var chuncks = input.Split('\n');
            var maxSoFar = chuncks[0].IndexOf('.') > 0 ? chuncks[0].Length : 0;
            var path = new List<string>();
            path.Add(chuncks[0]);
            for (int i = 1; i < chuncks.Length; ++i)
            {
                var chunck = chuncks[i];
                int localLevel = chunck.LastIndexOf('\t') + 1;
                chunck = chuncks[i].Substring(localLevel);
                if (localLevel < path.Count)
                {
                    path.RemoveRange(localLevel, path.Count - localLevel);
                }
                path.Add(chunck);
                int isFile = chunck.IndexOf('.');
                if (isFile > 0)
                {
                    var pathString = string.Join("/", path);
                    maxSoFar = Math.Max(maxSoFar, pathString.Length);
                }
            }
            return maxSoFar;
        }

        public bool ValidUtf8(int[] data)
        {
            int bytesToValidate = 0;

            foreach (int num in data)
            {
                if (bytesToValidate == 0)
                {
                    int bytesCount = this.GetCharLength(num);

                    if (bytesCount == 1 || bytesCount > 4)
                        return false;

                    bytesToValidate = bytesCount;

                    if (bytesCount > 1)
                        bytesToValidate--;
                }
                else
                {
                    int mask = 1 << 1;
                    if ((num >> 6) != mask)
                        return false;

                    bytesToValidate--;
                }
            }

            return bytesToValidate == 0;
        }

        private int GetCharLength(int num)
        {
            int count = 0;

            int mask = 1 << 7;
            while ((num & mask) != 0)
            {
                num = num << 1;
                count++;
            }

            return count;
        }

        public int LongestSubstring1(string s, int k)
        {
            if (k == 1) return s.Length;

            var dp = new int[s.Length + 1];

            var globalLongest = 0;

            for (int i = k - 1; i < s.Length; i++)
            {
                var charAndCount = new Dictionary<char, int>();
                var curCharHashSet = new HashSet<char>();
                var localLongest = 0;

                for (int j = i; j >= 0; j--)
                {
                    var curChar = s[j];

                    if (charAndCount.ContainsKey(curChar))
                    {
                        charAndCount[curChar]--;

                        if (charAndCount[curChar] == 0)
                        {
                            charAndCount.Remove(curChar);
                            curCharHashSet.Add(curChar);

                            if (charAndCount.Count == 0)
                            {
                                localLongest = i - j + 1 + dp[j + 1 - 1];
                                j -= dp[j + 1 - 1];

                            }
                        }
                    }
                    else
                    {
                        if (!curCharHashSet.Contains(curChar))
                        {
                            charAndCount[curChar] = k - 1;
                        }
                        else if (charAndCount.Count == 0)
                        {
                            localLongest = i - j + 1 + dp[j + 1 - 1];
                            j -= dp[j + 1 - 1];

                        }
                    }
                }

                dp[i + 1] = localLongest;
                globalLongest = Math.Max(globalLongest, localLongest);
            }

            return globalLongest;
        }

        public int LongestSubstring(string s, int k)
        {
            char[] str = s.ToCharArray();
            int[] counts = new int[26];
            int h, i, j, idx, max = 0, unique, noLessThanK;

            for (h = 1; h <= 26; h++)
            {
                for (int index = 0; index < 26; index++) counts[index] = 0;
                i = 0;
                j = 0;
                unique = 0;
                noLessThanK = 0;
                while (j < str.Length)
                {
                    if (unique <= h)
                    {
                        idx = str[j] - 'a';
                        if (counts[idx] == 0)
                            unique++;
                        counts[idx]++;
                        if (counts[idx] == k)
                            noLessThanK++;
                        j++;
                    }
                    else
                    {
                        idx = str[i] - 'a';
                        if (counts[idx] == k)
                            noLessThanK--;
                        counts[idx]--;
                        if (counts[idx] == 0)
                            unique--;
                        i++;
                    }
                    if (unique == h && unique == noLessThanK)
                        max = Math.Max(j - i, max);
                }
            }

            return max;
        }
        public int IntegerReplacement(int n)
        {
            if (n == int.MaxValue) return 32;

            if (n == 1)
                return 0;
            if (n % 2 == 1) return 1 + Math.Min(IntegerReplacement(n - 1),
                IntegerReplacement(n + 1));
            else return 1 + IntegerReplacement(n / 2);
        }

        public int MaxRotateFunction(int[] A)
        {

            int sum = 0;
            for (int i = 0; i < A.Length; i++) sum += A[i];

            int prev = 0;
            for (int i = 0; i < A.Length; i++) prev += i * A[i];

            int max = prev;
            for (int i = 1; i < A.Length; i++)
            {
                int curr = prev - sum + A[i - 1] * A.Length;
                max = curr > max ? curr : max;
                prev = curr;
            }

            return max;
        }

        public IList<int[]> PacificAtlantic(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            bool[,] pacific = new bool[rows, cols];
            bool[,] atlantic = new bool[rows, cols];

            // single queue per ocean - enqueue row then col
            Queue<int> pacificQueue = new Queue<int>();
            Queue<int> atlanticQueue = new Queue<int>();

            // set pacific left and alantic right to true and queue them
            for (int r = 0; r < rows; r++)
            {
                pacific[r, 0] = true;
                pacificQueue.Enqueue(r);
                pacificQueue.Enqueue(0);

                atlantic[r, cols - 1] = true;
                atlanticQueue.Enqueue(r);
                atlanticQueue.Enqueue(cols - 1);
            }

            // set pacific top and alantic bottom to true and queue them
            for (int c = 0; c < cols; c++)
            {
                pacific[0, c] = true;
                pacificQueue.Enqueue(0);
                pacificQueue.Enqueue(c);

                atlantic[rows - 1, c] = true;
                atlanticQueue.Enqueue(rows - 1);
                atlanticQueue.Enqueue(c);
            }

            // find pacific
            Traverse(matrix, pacificQueue, pacific);

            // find atlantic
            Traverse(matrix, atlanticQueue, atlantic);

            // find results where both pacific and atlantic are true
            IList<int[]> results = new List<int[]>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (pacific[r, c] && atlantic[r, c])
                    {
                        results.Add(new int[] { r, c });
                    }
                }
            }
            return results;
        }

        public void Traverse(int[,] matrix, Queue<int> queue, bool[,] visited)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            while (queue.Count > 0)
            {
                int r = queue.Dequeue();
                int c = queue.Dequeue();

                // left
                if (r > 0 && !visited[r - 1, c] && matrix[r - 1, c] >= matrix[r, c])
                {
                    visited[r - 1, c] = true;
                    queue.Enqueue(r - 1);
                    queue.Enqueue(c);
                }

                // right
                if (r < rows - 1 && !visited[r + 1, c] && matrix[r + 1, c] >= matrix[r, c])
                {
                    visited[r + 1, c] = true;
                    queue.Enqueue(r + 1);
                    queue.Enqueue(c);
                }

                // up
                if (c > 0 && !visited[r, c - 1] && matrix[r, c - 1] >= matrix[r, c])
                {
                    visited[r, c - 1] = true;
                    queue.Enqueue(r);
                    queue.Enqueue(c - 1);
                }

                // down
                if (c < cols - 1 && !visited[r, c + 1] && matrix[r, c + 1] >= matrix[r, c])
                {
                    visited[r, c + 1] = true;
                    queue.Enqueue(r);
                    queue.Enqueue(c + 1);
                }
            }
        }
        public int MinMutation(string start, string end, string[] bank)
        {
            Dictionary<string, HashSet<string>> groups = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i < 8; i++)
            {
                foreach (string word in bank)
                {
                    string key = this.GetKeyForGroupAtIndex(i, word);
                    this.AddGroup(key, word, groups);
                }
            }

            Queue<int> dq = new Queue<int>();
            Queue<string> q = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();
            q.Enqueue(start);
            dq.Enqueue(0);

            while (q.Count > 0)
            {
                string node = q.Dequeue();
                int depth = dq.Dequeue();

                if (node == end)
                {
                    return depth;
                }

                for (int i = 0; i < 8; i++)
                {
                    string key = this.GetKeyForGroupAtIndex(i, node);
                    if (!groups.ContainsKey(key))
                    {
                        continue;
                    }

                    foreach (string neighbor in groups[key])
                    {
                        if (visited.Contains(neighbor))
                        {
                            continue;
                        }

                        visited.Add(neighbor);
                        q.Enqueue(neighbor);
                        dq.Enqueue(depth + 1);
                    }
                }
            }

            return -1;
        }

        private string GetKeyForGroupAtIndex(int index, string word)
        {
            return word.Substring(0, index) + "_" + word.Substring(index + 1);
        }

        private void AddGroup(string key, string word, Dictionary<string, HashSet<string>> groups)
        {
            if (!groups.ContainsKey(key))
            {
                groups[key] = new HashSet<string>();
            }

            groups[key].Add(word);
        }

        public TreeNode MostLeft(TreeNode root)
        {
            if (root.left != null) return MostLeft(root.left);
            return root;
        }
        public TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null) return null;
            if (root.val == key)
            {
                if (root.left == null && root.right == null)
                {
                    return null;
                }
                else if (root.right != null)
                {
                    MostLeft(root.right).left = root.left;
                    return root.right;
                }
                else return root.left;
            }
            if (key < root.val) root.left = DeleteNode(root.left, key);
            else root.right = DeleteNode(root.right, key);
            return root;
        }

        public bool Find132pattern(int[] nums)
        {
            int i = 0;

            while (i < nums.Length - 2)
            {
                // advance i while numbers are decreasing
                while (i < nums.Length - 1 && nums[i + 1] <= nums[i]) i++;

                // advance j while numbers are increasing and greater than nums[i]
                int j = i + 1;
                while (j < nums.Length - 1 && (nums[j] <= nums[i] || nums[j + 1] >= nums[j])) j++;

                // test elements beyond j for value between nums[i] and nums[j]
                for (int k = j + 1; k < nums.Length; k++)
                {
                    if (nums[k] > nums[i] && nums[k] < nums[j]) return true;
                }

                // not found, restart after j
                i = j + 1;
            }

            return false;
        }

        public bool CircularArrayLoop(int[] nums)
        {
            if (nums.Length < 2) return false;

            int indexSlow = 0;
            int indexFast = 0;
            int count = 0;
            int steps = 0;
            int len = nums.Length;
            bool forward = nums[0] > 0;

            do
            {
                if ((forward && (nums[indexSlow] < 0 || nums[indexFast] < 0))
                        || (!forward && (nums[indexSlow] > 0 || nums[indexFast] > 0)))
                {
                    return false;
                }

                steps += Math.Abs(nums[indexSlow]);
                indexSlow = Mod(Next(nums, indexSlow), len);
                indexFast = Mod(Next(nums, indexFast), len);
                indexFast = Mod(Next(nums, indexFast), len);
                count++;
            }
            while (count < nums.Length && indexSlow != indexFast);

            return indexSlow == indexFast && steps > 1;
        }

        public int Next(int[] nums, int index)
        {
            int len = nums.Length;
            int forward = nums[index];
            return Mod(index + forward, len);
        }

        public int Mod(int val, int len)
        {
            return ((val % len) + len) % len;
        }

        public bool CanIWin(int maxChoosableInteger, int desiredTotal)
        {
            int[] mem = new int[1 << maxChoosableInteger];

            if ((maxChoosableInteger * (maxChoosableInteger + 1) / 2) < desiredTotal) return false;
            return CanWin(mem, 0, maxChoosableInteger, desiredTotal);
        }

        public bool CanWin(int[] mem, int state, int max, int target)
        {
            if (mem[state] != 0) return mem[state] == 1 ? true : false;

            bool win = false;
            for (int i = 1, b = 1 << (i - 1); i <= max; i++, b = 1 << (i - 1))
            {
                if ((state & b) != 0) continue;
                if (i >= target || !CanWin(mem, state | b, max, target - i)) { win = true; break; }
            }

            mem[state] = win ? 1 : -1;

            return win;
        }

        public int FindSubstringInWraproundString(string p)
        {
            // count[i] is the maximum unique substring end with ith letter.
            // 0 - 'a', 1 - 'b', ..., 25 - 'z'.
            int[] count = new int[26];

            // store longest contiguous substring ends at current position.
            int maxLengthCur = 0;

            for (int i = 0; i < p.Length; i++)
            {
                if (i > 0 && (p[i] - p[i - 1] == 1 || (p[i - 1] - p[i] == 25)))
                {
                    maxLengthCur++;
                }
                else
                {
                    maxLengthCur = 1;
                }

                int index = p[i] - 'a';
                count[index] = Math.Max(count[index], maxLengthCur);
            }

            // Sum to get result
            int sum = 0;
            for (int i = 0; i < 26; i++)
            {
                sum += count[i];
            }
            return sum;
        }

        public string ValidIPAddress(string IP)
        {
            if (IsIp4(IP)) return "IPv4";
            if (IsIp6(IP)) return "IPv6";
            return "Neither";
        }

        private bool IsIp4(string s)
        {
            string[] parts = s.Split(new char[] { '.' });
            if (parts.Length != 4) return false;

            int x = 0;
            foreach (string p in parts)
            {
                if (!Int32.TryParse(p, out x)) return false;
                if (x < 0 || x > 255 || (x.ToString().Length != p.Length)) return false;
            }
            return true;
        }

        private bool IsIp6(string s)
        {
            string[] parts = s.Split(new char[] { ':' });
            if (parts.Length != 8) return false;

            int x = 0;
            foreach (string p in parts)
            {
                if (p.Length > 4) return false;

                if (!Int32.TryParse(
                        p,
                        System.Globalization.NumberStyles.HexNumber,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out x)) return false;

                if (x < 0) return false;
            }
            return true;
        }

        public bool CanPartition(int[] nums)
        {
            if (nums == null || nums.Length < 2) return false;
            int sum = nums.Sum();

            if (sum % 2 == 1) return false;
            if (2 * nums.Max() > sum) return false;
            return DoDfs(nums, 0, sum / 2, 0);
        }

        public bool DoDfs(int[] nums, int start, int sum, int current_sum)
        {
            if (start == nums.Length) return false;
            int prev = -1;

            for (int i = start; i < nums.Length; i++)
            {
                if (nums[i] == prev) continue;
                prev = nums[i];

                int temp_sum = current_sum + nums[i];
                if (temp_sum == sum) return true;
                if (temp_sum < sum)
                {

                    if (DoDfs(nums, i + 1, sum, temp_sum))
                        return true;

                }
            }
            return false;
        }

        public string RemoveKdigits(string num, int k)
        {
            int remain = num.Length - k;
            char[] numArray = num.ToCharArray(), res = new char[remain];
            int index = 0;
            for (int i = 0; i < numArray.Length; i++)
            {
                // (1)  (n - i > remain - index): have enough remaining digits to be compared
                // (2)  (res[index - 1] > nums[i]): at this time, the (index-1) is the newest added digit,
                //      compare this digit with the current num, if the res is greater and you have enough 
                //      remaining digits to be compared, decrease the index(it ensures that the future added digit is 
                //      always smaller than before and the size is remain) until get the right and 'safe' position
                while ((numArray.Length - i > remain - index) && (index > 0 && numArray[i] < res[index - 1])) index--;
                if (index < remain) res[index++] = numArray[i];
            }

            // check leading zeroes
            index = -1;
            while (++index < remain)
            {
                if (res[index] != '0') break;
            }
            String s = new String(res).Substring(index);

            return s.Length == 0 ? "0" : s;
        }

        public IList<int[]> KSmallestPairs(int[] nums1, int[] nums2, int k)
        {
            IList<int[]> list = new List<int[]>();

            k = Math.Min(k, nums1.Length * nums2.Length);
            int[] idx = new int[Math.Min(k, nums1.Length)];

            while (list.Count < k)
            {
                // find next smallest pair
                int minPairIndex = -1;
                for (int i = 0; i < idx.Length; i++)
                {
                    // skip num1 elems that have already used all their pairs
                    if (idx[i] < nums2.Length)
                    {
                        if (minPairIndex == -1 || nums1[i] + nums2[idx[i]] < nums1[minPairIndex] + nums2[idx[minPairIndex]])
                        {
                            minPairIndex = i;
                        }
                    }
                }

                list.Add(new int[] { nums1[minPairIndex], nums2[idx[minPairIndex]] });
                idx[minPairIndex]++;
            }

            return list;
        }

        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            var dict = new Dictionary<int, List<IList<int>>>();
            var result = new List<IList<int>>();
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                List<IList<int>> subResult;
                if (!dict.TryGetValue(nums[i], out subResult))
                {
                    subResult = new List<IList<int>>();
                    dict[nums[i]] = subResult;
                }
                var list = new HashSet<int>();
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] >= nums[i])
                        list.Add(nums[j]);
                }

                var originalSize = dict[nums[i]].Count;
                foreach (var item in list)
                {
                    var itemResult = dict[item];
                    var size = itemResult.Count;
                    if (item == nums[i])
                        size = originalSize;
                    var solution = new List<int>();
                    solution.Add(nums[i]);
                    solution.Add(item);
                    subResult.Add(solution);

                    for (var k = 0; k < size; k++)
                    {
                        solution = new List<int>();
                        solution.Add(nums[i]);
                        solution.AddRange(itemResult[k]);
                        subResult.Add(solution);
                    }

                    if (item == nums[i])
                        subResult.RemoveRange(0, originalSize);
                }
            }

            foreach (var res in dict.Values)
                result.AddRange(res);

            return result;
        }

        public int Change(int amount, int[] coins)
        {
            // order coins in order to prune recursion
            Array.Sort(coins);

            // init memorization to -1 (unvisited)
            int[,] map = new int[amount + 1, coins.Length];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++) map[i, j] = -1;
            }

            // DFS
            return Count(coins, amount, 0, map);
        }

        public int Count(int[] coins, int amount, int index, int[,] map)
        {
            if (amount == 0) return 1;
            if (index == coins.Length) return 0;
            if (map[amount, index] != -1) return map[amount, index];

            int cnt = 0;
            for (int i = index; i < coins.Length; i++)
            {
                if (coins[i] > amount) break;

                // using this coin as many times as possible before going to next coin
                int times = 1;
                while (times * coins[i] <= amount)
                {
                    cnt += Count(coins, amount - times * coins[i], i + 1, map);
                    times++;
                }
            }

            // memorize
            map[amount, index] = cnt;
            return cnt;
        }
        Dictionary<string, int> dict = new Dictionary<string, int>();
        int max = -1;
        public int FindLUSlength(string[] strs)
        {

            foreach (var str in strs)
            {
                var subseqs = GetSubSeq(str);

                foreach (var subseq in subseqs)
                {
                    if (!dict.ContainsKey(subseq))
                    {
                        dict[subseq] = 0;
                    }
                    dict[subseq]++;
                }
            }

            foreach (var kv in dict)
            {
                if (kv.Value == 1)
                {
                    max = Math.Max(max, kv.Key.Length);
                }
            }

            return max;
        }

        public IList<string> GetSubSeq(string s)
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(s))
            {
                list.Add(string.Empty);
                return list;
            }

            var subseqs = GetSubSeq(s.Substring(1));
            var res = new List<string>(subseqs);
            foreach (var sub in subseqs)
            {
                list.Add(s[0] + sub);
            }
            res.AddRange(list);
            return res;
        }

        public bool CheckSubarraySum1(int[] nums, int k)
        {
            for (int start = 0; start < nums.Length - 1; start++)
            {
                for (int end = start + 1; end < nums.Length; end++)
                {
                    int sum = 0;
                    for (int i = start; i <= end; i++)
                        sum += nums[i];

                    if (sum == k || (k != 0 && sum % k == 0))
                        return true;
                }
            }
            return false;
        }

        public bool CheckSubarraySum(int[] nums, int k)
        {
            if (nums.Length == 0) return false; // Input is empty
            if (k == 0)
            { // If k equals 0, the only solution is two consecutive 0s
                for (int i = 0; i < nums.Length - 1; i++)
                    if (nums[i] + nums[i + 1] == 0) return true;
                return false;
            }
            k = k < 0 ? -k : k; // make sure k is positive
            if (nums.Length > k) return true; // we have (k + 1) prefix sum but k remainder, there is at least two prefix with the same remainder

            int sum = 0;
            HashSet<int> set = new HashSet<int>();
            foreach (int num in nums)
            {
                int tmp = sum;
                sum = (sum + num) % k;
                if (set.Contains(sum)) return true;
                set.Add(tmp); // the subarray length is at least 2
            }
            return false;
        }

        public int[,] UpdateMatrix(int[,] matrix)
        {
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);

            if (row == 0) return new int[0, 0];

            var result = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (matrix[i, j] == 0) continue;

                    var distance = UpdateMatrixBFS(matrix, i, j);
                    result[i, j] = distance;
                }
            }

            return result;
        }

        private int UpdateMatrixBFS(int[,] matrix, int startX, int startY)
        {
            var row = matrix.GetLength(0);
            var col = matrix.GetLength(1);

            var directions = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

            var queue = new Queue<Tuple<int, int>>();

            queue.Enqueue(Tuple.Create(startX, startY));
            var distance = 1;
            while (queue.Any())
            {
                var size = queue.Count;

                for (int z = 0; z < size; z++)
                {
                    var cur = queue.Dequeue();

                    for (int i = 0; i < directions.GetLength(0); i++)
                    {
                        var directionX = directions[i, 0];
                        var directionY = directions[i, 1];

                        var nextX = cur.Item1 + directionX;
                        var nextY = cur.Item2 + directionY;

                        if (nextX < 0 || nextX >= row || nextY < 0 || nextY >= col) continue;

                        if (matrix[nextX, nextY] == 0) return distance;

                        queue.Enqueue(Tuple.Create(nextX, nextY));
                    }
                }

                distance++;
            }

            return distance;
        }

        public int NextGreaterElement(int n)
        {
            char[] number = (n + "").ToCharArray();

            int i, j;
            // I) Start from the right most digit and 
            // find the first digit that is
            // smaller than the digit next to it.
            for (i = number.Length - 1; i > 0; i--)
                if (number[i - 1] < number[i])
                    break;

            // If no such digit is found, its the edge case 1.
            if (i == 0)
                return -1;

            // II) Find the smallest digit on right side of (i-1)'th 
            // digit that is greater than number[i-1]
            int x = number[i - 1], smallest = i;
            for (j = i + 1; j < number.Length; j++)
                if (number[j] > x && number[j] <= number[smallest])
                    smallest = j;

            // III) Swap the above found smallest digit with 
            // number[i-1]
            char temp = number[i - 1];
            number[i - 1] = number[smallest];
            number[smallest] = temp;

            // IV) Sort the digits after (i-1) in ascending order
            Array.Sort(number, i, number.Length - i);

            long val = long.Parse(new String(number));
            return (val <= int.MaxValue) ? (int)val : -1;
        }

        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length || s1.Length == 0 || s1 == "") return false;
            int[] count = new int[26];
            for (int i = 0; i < s1.Length; i++)
            {
                count[s1[i] - 'a']++;
                count[s2[i] - 'a']--;
            }
            int j = 0;
            while (j <= s2.Length - s1.Length)
            {
                if (CheckInclusion_optimize_helper(count) == true) return true;
                if (j == s2.Length - s1.Length) break;
                count[s2[j] - 'a']++;
                count[s2[j + s1.Length] - 'a']--;
                j++;
            }
            return false;
        }
        private bool CheckInclusion_optimize_helper(int[] count)
        {
            for (int i = 0; i < count.Length; i++)
                if (count[i] != 0)
                    return false;
            return true;
        }

        public string SolveEquation(string equation)
        {

            int countX = 0;
            int countV = 0;

            int sign = 1;
            int psign = 1;
            int n = 0;
            equation = equation + "-";
            bool startWith0 = false;
            int len = equation.Length;
            for (int i = 0; i < len; i++)
            {
                if (equation[i] == '+')
                {
                    n *= sign * psign;
                    if (i > 0 && equation[i - 1] == 'x')
                    {
                        countX += n;
                    }
                    else
                    {
                        countV += n;
                    }
                    sign = 1;
                    n = 0;
                }
                else if (equation[i] == '-')
                {
                    n *= sign * psign;
                    if (i > 0 && equation[i - 1] == 'x')
                    {
                        countX += n;
                    }
                    else
                    {
                        countV += n;
                    }
                    sign = -1;
                    n = 0;
                }
                else if (equation[i] == '=')
                {
                    n *= sign * psign;
                    if (i > 0 && equation[i - 1] == 'x')
                    {
                        countX += n;
                    }
                    else
                    {
                        countV += n;
                    }
                    sign = 1;
                    psign = -1;
                    n = 0;
                }
                else if (equation[i] != 'x')
                {
                    n = n * 10 + (equation[i] - '0');
                }
                else if (n == 0 && (i == 0 || equation[i - 1] == '+' || equation[i - 1] == '-' || equation[i - 1] == '='))
                {
                    n = 1;
                }
                //Console.WriteLine(countX+","+countV+","+n);
            }

            countV = -countV;

            if (countX == 0 && countV == 0)
            {
                return "Infinite solutions";
            }
            else if (countX == 0 && countV != 0)
            {
                return "No solution";
            }
            else
            {
                return "x=" + (countV / countX);
            }

        }
        public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            if (Distance(p1, p2) == 0 || Distance(p2, p3) == 0 || Distance(p3, p4) == 0 || Distance(p1, p4) == 0) return false;
            return (Distance(p1, p2) == Distance(p3, p4) && Distance(p1, p3) == Distance(p2, p4) && Distance(p1, p4) == Distance(p2, p3) && (Distance(p1, p2) == Distance(p1, p3) || Distance(p1, p2) == Distance(p1, p4) || Distance(p1, p3) == Distance(p1, p4)));
        }

        public int Distance(int[] p1, int[] p2)
        {
            var x = (p1[0] - p2[0]);
            var y = (p1[1] - p2[1]);
            return x * x + y * y;
        }

        public bool CheckValidString(string s)
        {
            int low = 0;
            int high = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    low++;
                    high++;
                }
                else if (s[i] == ')')
                {
                    if (low > 0)
                    {
                        low--;
                    }
                    high--;
                }
                else
                {
                    if (low > 0)
                    {
                        low--;
                    }
                    high++;
                }
                if (high < 0)
                {
                    return false;
                }
            }
            return low == 0;
        }

        public int FindNumberOfLIS(int[] nums)
        {
            if (null == nums || nums.Length == 0) return 0;
            int[] lengthOfLisAtIndex = new int[nums.Length];   //Length of the Longest Increasing Subsequence which ends with nums[i].
            int[] numberOfLisAtIndex = new int[nums.Length];   //Number of the Longest Increasing Subsequence which ends with nums[i].

            for (int i = 0; i < nums.Length; i++)
            {
                lengthOfLisAtIndex[i] = 1;
                numberOfLisAtIndex[i] = 1;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        if (lengthOfLisAtIndex[j] + 1 > lengthOfLisAtIndex[i])
                        {
                            lengthOfLisAtIndex[i] = lengthOfLisAtIndex[j] + 1;
                            numberOfLisAtIndex[i] = numberOfLisAtIndex[j];
                        }
                        else if (lengthOfLisAtIndex[j] + 1 == lengthOfLisAtIndex[i])
                        {
                            numberOfLisAtIndex[i] += numberOfLisAtIndex[j];
                        }
                    }
                }
            }

            int maxlen = lengthOfLisAtIndex.Max();
            int ans = 0;
            for (int i = 0; i < lengthOfLisAtIndex.Length; i++)
                if (lengthOfLisAtIndex[i] == maxlen)
                    ans += numberOfLisAtIndex[i];

            return ans;
        }
        public string PredictPartyVictory(string senate)
        {
            int r = 0, d = 0, start = 0;
            char[] arr = senate.ToCharArray();
            foreach (char c in arr)
            {
                if (c == 'R') r++;
                else d++;
            }

            while (r > 0 && d > 0)
            {
                while (arr[start] != 'R' && arr[start] != 'D')
                {
                    start = (start + 1) % arr.Length;
                }

                char ban = 'R';
                if (arr[start] == 'R')
                {
                    ban = 'D';
                    d--;
                }
                else
                {
                    r--;
                }
                int idx = (start + 1) % arr.Length;
                while (arr[idx] != ban)
                {
                    idx = (idx + 1) % arr.Length;
                }

                arr[idx] = ' ';
                start = (start + 1) % arr.Length;
            }

            return d == 0 ? "Radiant" : "Dire";
        }

        public bool IsPossible(int[] nums)
        {
            if (nums == null || nums.Length < 3)
            {
                return false;
            }

            List<List<int>> lists = new List<List<int>>();
            var l1 = new List<int>();
            l1.Add(nums[0]);
            lists.Add(l1);

            for (int i = 1; i < nums.Length; i++)
            {
                bool added = false;
                var temp = new List<List<int>>();

                foreach (var item in lists)
                {
                    if (item.Last() + 1 == nums[i])
                    {
                        item.Add(nums[i]);
                        added = true;
                        break;
                    }
                    else if (item.Last() + 1 < nums[i])
                    {
                        temp.Add(item);
                    }
                }

                if (temp.Where((x) => x.Count < 3).Count() > 0)
                {
                    return false;
                }

                else
                {
                    foreach (var item in temp)
                    {
                        lists.Remove(item);
                    }
                }
                if (!added)
                {
                    var l = new List<int>();
                    l.Add(nums[i]);
                    lists.Insert(0, l);
                }
            }

            return lists.Where((x) => x.Count < 3).Count() == 0;
        }

        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            int lo = 0, hi = arr.Length - k;
            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (x - arr[mid] > arr[mid + k] - x)
                    lo = mid + 1;
                else
                    hi = mid;
            }
            IList<int> result = new List<int>();
            for (int i = 0; i < k; i++)
                result.Add(arr[lo + i]);
            return result;

        }

        public int MaximumSwap(int num)
        {
            char[] digits = num.ToString().ToCharArray();

            int[] buckets = new int[10];
            for (int i = 0; i < digits.Length; i++)
            {
                buckets[digits[i] - '0'] = i;
            }

            for (int i = 0; i < digits.Length; i++)
            {
                for (int k = 9; k > digits[i] - '0'; k--)
                {
                    if (buckets[k] > i)
                    {
                        char tmp = digits[i];
                        digits[i] = digits[buckets[k]];
                        digits[buckets[k]] = tmp;
                        return int.Parse(new String(digits));
                    }
                }
            }

            return num;
        }

        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            int sum = 0;
            foreach (int num in nums) sum += num;
            if (k <= 0 || sum % k != 0) return false;
            int[] visited = new int[nums.Length];
            return canPartition(nums, visited, 0, k, 0, 0, sum / k);
        }

        public bool canPartition(int[] nums, int[] visited, int start_index, int k, int cur_sum, int cur_num, int target)
        {
            if (k == 1) return true;
            if (cur_sum == target && cur_num > 0) return canPartition(nums, visited, 0, k - 1, 0, 0, target);
            for (int i = start_index; i < nums.Length; i++)
            {
                if (visited[i] == 0)
                {
                    visited[i] = 1;
                    if (canPartition(nums, visited, i + 1, k, cur_sum + nums[i], cur_num++, target)) return true;
                    visited[i] = 0;
                }
            }
            return false;
        }

        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k == 0) return 0;
            int cnt = 0;
            int pro = 1;
            for (int i = 0, j = 0; j < nums.Length; j++)
            {
                pro *= nums[j];
                while (i <= j && pro >= k)
                {
                    pro /= nums[i++];
                }
                cnt += j - i + 1;
            }
            return cnt;
        }
        public IList<string> RemoveComments(string[] source)
        {
            List<String> res = new List<string>();
            StringBuilder sb = new StringBuilder();
            bool mode = false;
            foreach (String s in source)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (mode)
                    {
                        if (s[i] == '*' && i < s.Length - 1 && s[i + 1] == '/')
                        {
                            mode = false;
                            i++;        //skip '/' on next iteration of i
                        }
                    }
                    else
                    {
                        if (s[i] == '/' && i < s.Length - 1 && s[i + 1] == '/')
                        {
                            break;      //ignore remaining characters on line s
                        }
                        else if (s[i] == '/' && i < s.Length - 1 && s[i + 1] == '*')
                        {
                            mode = true;
                            i++;           //skip '*' on next iteration of i
                        }
                        else sb.Append(s[i]);     //not a comment
                    }
                }
                if (!mode && sb.Length > 0)
                {
                    res.Add(sb.ToString());
                    sb = new StringBuilder();   //reset for next line of source code
                }
            }
            return res;
        }

        public int ReachNumber(int target)
        {
            target = Math.Abs(target);
            int step = 0;
            int sum = 0;
            while (sum < target)
            {
                step++;
                sum += step;
            }
            while ((sum - target) % 2 != 0)
            {
                step++;
                sum += step;
            }
            return step;
        }
        public int NetworkDelayTime(int[,] times, int N, int K)
        {
            // convert the information in times to 2-D graph array, set the element to -1 by default
            int[,] graph = new int[N, N];
            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j)
                    graph[i, j] = -1;
            for (int i = 0; i < times.GetLength(0); ++i)
                graph[times[i, 0] - 1, times[i, 1] - 1] = times[i, 2];

            Queue q = new Queue();
            for (int i = 0; i < N; ++i)
            {
                if (graph[K - 1, i] != -1)
                    q.Enqueue(i);
            }
            while (q.Count > 0)
            {
                int x = (int)q.Dequeue();
                for (int i = 0; i < N; ++i)
                {
                    if (i != K - 1 && graph[x, i] != -1)
                    {
                        if (graph[K - 1, i] == -1 || graph[K - 1, x] + graph[x, i] < graph[K - 1, i])
                        {
                            graph[K - 1, i] = graph[K - 1, x] + graph[x, i];
                            q.Enqueue(i);
                        }
                    }
                }
            }
            int res = 0;
            for (int i = 0; i < N; ++i)
            {
                if (i == K - 1)
                    continue;
                if (graph[K - 1, i] == -1)
                    return -1;
                if (graph[K - 1, i] > res)
                    res = graph[K - 1, i];
            }
            return res;
        }

        double[,] memo = new double[200,200];
        public double SoupServings(int N)
        {
            return N >= 4800 ? 1.0 : f((N + 24) / 25, (N + 24) / 25);
        }

        public double f(int a, int b)
        {
            if (a <= 0 && b <= 0) return 0.5;
            if (a <= 0) return 1;
            if (b <= 0) return 0;
            if (memo[a,b] > 0) return memo[a,b];
            memo[a,b] = 0.25 * (f(a - 4, b) + f(a - 3, b - 1) + f(a - 2, b - 2) + f(a - 1, b - 3));
            return memo[a,b];
        }

        public int ExpressiveWords(string S, string[] words)
        {
            int res = 0;
            foreach (String W in words) if (check(S, W)) res++;
            return res;
        }
        public bool check(String S, String W)
        {
            int n = S.Length, m = W.Length, j = 0;
            for (int i = 0; i < n; i++)
                if (j < m && S[i] == W[j]) j++;
                else if (i > 1 && S[i] == S[i - 1] && S[i - 1] == S[i - 2]) ;
                else if (0 < i && i < n - 1 && S[i - 1] == S[i] && S[i] == S[i + 1]) ;
                else return false;
            return j == m;
        }

        public int Flipgame(int[] fronts, int[] backs)
        {
            HashSet<int> same = new HashSet<int>();
            for (int i = 0; i < fronts.Length; ++i) if (fronts[i] == backs[i]) same.Add(fronts[i]);
            int res = 3000;
            foreach (int i in fronts) if (!same.Contains(i)) res = Math.Min(res, i);
            foreach (int i in backs) if (!same.Contains(i)) res = Math.Min(res, i);
            return res % 3000;
        }

        public int NumFactoredBinaryTrees(int[] A)
        {
            if (A == null || A.Length == 0)
            {
                return 0;
            }

            // prepare
            Array.Sort(A);
            int mod = ((int)Math.Pow(10, 9)) + 7;

            // val => index
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < A.Length; i++)
            {
                dictionary[A[i]] = i;
            }

            // dp
            long[] dp = new long[A.Length];

            long result = 0;
            for (int i = 0; i < A.Length; i++)
            {
                long ans = 1;
                for (int right = i - 1; right >= 0; right--)
                {
                    int check = A[right];
                    if ((A[i] % A[right]) == 0 && dictionary.ContainsKey(A[i] / A[right]))
                    {
                        int left = dictionary[A[i] / A[right]];
                        ans += dp[left] * dp[right];
                        ans %= mod;
                    }
                }

                dp[i] = ans;
                result += ans;
                result %= mod;
            }
            return (int)result;
        }


        public int NumFriendRequests(int[] ages)
        {
            int res = 0;
            var ppl = new int[121];

            for (int i = 0; i < ages.Length; i++)
            {
                ppl[ages[i]]++;
            }

            for (int i = 1; i < ppl.Length; i++)
            {
                for (int j = 1; j < ppl.Length; j++)
                {
                    if (!(j <= (0.5 * i + 7) || j > i || (j > 100 && i < 100)))
                    {
                        if (i == j)
                        {
                            res += (ppl[i] * (ppl[i] - 1));
                        }
                        else
                        {
                            res += (ppl[i] * ppl[j]);
                        }
                    }
                }
            }
            return res;
        }

        public int ConsecutiveNumbersSum(int N)
        {
            int res = 1, count;
            while (N % 2 == 0) N /= 2;
            for (int i = 3; i * i <= N; res *= count + 1, i += 2)
                for (count = 0; N % i == 0; N /= i, count++) ;
            return N == 1 ? res : res * 2;

        }

        public double New21Game(int N, int K, int W)
        {
            if (K == 0 || N >= K + W) return 1;
            double[] dp = new double[N + 1]; double Wsum = 1, res = 0;
            dp[0] = 1;
            for (int i = 1; i <= N; ++i)
            {
                dp[i] = Wsum / W;
                if (i < K) Wsum += dp[i]; else res += dp[i];
                if (i - W >= 0) Wsum -= dp[i - W];
            }
            return res;
        }

        public int LongestMountain(int[] A)
        {
            int N = A.Length, res = 0;
            int[] up = new int[N], down = new int[N];
            for (int i = N - 2; i >= 0; --i) if (A[i] > A[i + 1]) down[i] = down[i + 1] + 1;
            for (int i = 0; i < N; ++i)
            {
                if (i > 0 && A[i] > A[i - 1]) up[i] = up[i - 1] + 1;
                if (up[i] > 0 && down[i] > 0) res = Math.Max(res, up[i] + down[i] + 1);
            }
            return res;
        }
        public string ShiftingLetters(string S, int[] shifts)
        {
            StringBuilder res = new StringBuilder(S);
            for (int i = shifts.Length - 2; i >= 0; i--) shifts[i] = (shifts[i] + shifts[i + 1]) % 26;
            for (int i = 0; i < S.Length; i++) res[i] = (char)((S[i] - 'a' + shifts[i]) % 26 + 'a');
            return res.ToString();
        }

        public int SmallestRangeII(int[] A, int K)
        {
            Array.Sort(A);
            int n = A.Length, mx = A[n - 1], mn = A[0], res = mx - mn;
            for (int i = 0; i < n - 1; ++i)
            {
                mx = Math.Max(mx, A[i] + 2 * K);
                mn = Math.Min(A[i + 1], A[0] + 2 * K);
                res = Math.Min(res, mx - mn);
            }
            return res;
        }

        public int PartitionDisjoint(int[] A)
        {
            int n = A.Length, pmax = 0; int[] B = new int[n];
            B[n - 1] = A[n - 1];
            for (int i = n - 2; i > 0; --i)
                B[i] = Math.Min(A[i], B[i + 1]);
            for (int i = 1; i < n; ++i)
            {
                pmax = Math.Max(pmax, A[i - 1]);
                if (pmax <= B[i]) return i;
            }
            return n;
        }

        public int PrimePalindrome1(int N)
        {
            if (8 <= N && N <= 11) return 11;
            for (int x = 1; x < 100000; x++)
            {
                String s = x.ToString(), r = new StringBuilder(s).ToString();
                r = r.Reverse().ToString().Substring(1);
                int y = int.Parse(s + r);
                if (y >= N && isPrime1(y)) return y;
            }
            return -1;
        }

        public Boolean isPrime1(int x)
        {
            if (x < 2 || x % 2 == 0) return x == 2;
            for (int i = 3; i * i <= x; i += 2)
                if (x % i == 0) return false;
            return true;
        }
        public int PrimePalindrome(int N)
        {
            if (N == 1 || N == 2) return 2;
            if (N % 2 == 0) N++;
            while (true)
            {
                if (isPalindrome(N) && isPrime(N)) return N;
                N += 2;
                //if (10_000_000 < N && N < 100_000_000)
                //N = 100_000_001;
            }
        }

        private bool isPalindrome(int n)
        {
            if (n % 10 == 0 && n != 0) return false;
            int n1 = 0;
            while (n > n1)
            {
                n1 = n1 * 10 + (n % 10);
                n /= 10;
            }
            return n1 == n || n == n1 / 10;
        }

        private bool isPrime(int n)
        {
            int end = (int)Math.Sqrt(n);
            for (int i = 3; i <= end; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public int SubarrayBitwiseORs(int[] A)
        {
            HashSet<int> res = new HashSet<int>(), cur = new HashSet<int>(), cur2;
            foreach (int i in A)
            {
                cur2 = new HashSet<int>();
                cur2.Add(i);
                foreach (int j in cur) cur2.Add(i | j);
                cur = cur2;
                foreach (int k in cur) res.Add(k);
            }
            return res.Count;
        }

        public int NumRescueBoats(int[] people, int limit)
        {
            Array.Sort(people);
            int i, j;
            for (i = 0, j = people.Length - 1; i <= j; --j)
                if (people[i] + people[j] <= limit) ++i;
            return people.Length - 1 - j;
        }

        public IList<IList<string>> AccountsMerge1(IList<IList<string>> accounts)
        {
            Dictionary<string, HashSet<string>> graphOfEmails = new Dictionary<String, HashSet<string>>();  //<Email -> NeighboringEmail
            Dictionary<string, string> emailToNameMap = new Dictionary<string, string>();                   //<Email-> Name         
            foreach (List<String> account in accounts)
            {
                String name = account[0];
                for (int i = 1; i < account.Count; i++)
                {
                    if (!graphOfEmails.ContainsKey(account[i]))
                    {
                        graphOfEmails.Add(account[i], new HashSet<string>());
                    }
                    emailToNameMap[account[i]] = name;
                    if (i == 1) continue;
                    graphOfEmails[account[i]].Add(account[i - 1]);
                    graphOfEmails[account[i - 1]].Add(account[i]);
                }
            }

            //DFS
            IList<IList<string>> mergedAccounts = new List<IList<string>>();
            List<string> visited = new List<string>();
            foreach (string email in emailToNameMap.Keys)
            {
                if (!visited.Contains(email))
                {
                    SortedSet<string> connectedEmails = new SortedSet<string>(StringComparer.Ordinal);
                    DFS(graphOfEmails, email, connectedEmails, visited);
                    IList<string> mergedAccount = new List<string>();
                    mergedAccount.Add(emailToNameMap[email]);
                    foreach (string connectedEmail in connectedEmails)
                    {
                        mergedAccount.Add(connectedEmail);
                    }
                    mergedAccounts.Add(mergedAccount);
                }
            }
            return mergedAccounts;
        }

        private static void DFS(Dictionary<string, HashSet<string>> graphOfEmails, string email, SortedSet<string> connectedEmails, List<string> visited)
        {
            if (visited.Contains(email))
                return;
            connectedEmails.Add(email);
            visited.Add(email);
            HashSet<string> neighboringEmails = graphOfEmails[email];
            foreach (string neighboringEmail in neighboringEmails)
            {
                DFS(graphOfEmails, neighboringEmail, connectedEmails, visited);
            }
        }

        private int findParent(int i, int[] accP)
        {
            if (accP[i] != i) accP[i] = findParent(accP[i], accP);
            return accP[i];
        }
        private void union(int i, int j, int[] accP, int[] accCnt)
        {
            int iP = findParent(i, accP);
            int jP = findParent(j, accP);
            if (iP != jP)
            {
                if (accCnt[iP] >= accCnt[jP])
                {
                    accP[jP] = iP;
                    accCnt[iP] += accCnt[jP];
                    accCnt[jP] = 0;
                }
                else
                {
                    accP[iP] = jP;
                    accCnt[jP] += accCnt[iP];
                    accCnt[iP] = 0;
                }
            }
        }
        public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string[] acc = new string[accounts.Count];
            int[] accCnt = new int[accounts.Count];
            int[] accP = new int[accounts.Count];
            int mergeCnt = 0;
            for (int i = 0; i < accounts.Count; i++)
            {
                acc[i] = accounts[i][0];
                accCnt[i] = accounts[i].Count - 1;
                accP[i] = i;
                int accI = i;
                for (int j = 1; j < accounts[i].Count; j++)
                {
                    if (dic.ContainsKey(accounts[i][j]))
                    {
                        union(dic[accounts[i][j]], accI, accP, accCnt);
                    }
                    else dic.Add(accounts[i][j], accI);
                }
            }
            int[] accMap = new int[acc.Length];
            int mapCnt = 0;
            IList<IList<string>> ansList = new List<IList<string>>();
            for (int i = 0; i < accCnt.Length; i++)
            {
                if (accCnt[i] > 0)
                {
                    accMap[i] = mapCnt;
                    ansList.Add(new List<string>());
                    ansList[mapCnt].Add(acc[i]);
                    mapCnt++;
                }
            }
            foreach (var kv in dic) ansList[accMap[findParent(kv.Value, accP)]].Add(kv.Key);
            for (int i = 0; i < ansList.Count; i++)
            {
                List<string> list = (List<string>)ansList[i];
                list.Sort(1, ansList[i].Count - 1, StringComparer.Ordinal);
                ansList[i] = list;
            }
            return ansList;
        }

        public int[] AsteroidCollision(int[] asteroids)
        {
            if (asteroids == null || asteroids.Length == 0)
                return null;

            var stack = new Stack<int>();
            stack.Push(asteroids[0]);

            for (int i = 1; i < asteroids.Length; i++)
            {
                while (true)
                {
                    if (stack.Count > 0 && stack.Peek() > 0 && asteroids[i] < 0)
                    {
                        if (Math.Abs(stack.Peek()) == Math.Abs(asteroids[i]))
                        {
                            stack.Pop();
                            break;
                        }

                        else if (Math.Abs(stack.Peek()) < Math.Abs(asteroids[i]))
                            stack.Pop();
                        else break;
                    }
                    else
                    {
                        stack.Push(asteroids[i]);
                        break;
                    }
                }
            }

            return stack.Reverse().ToArray();
        }

        public struct CharacterCount : IComparable<CharacterCount>
        {
            public char Cha { get; set; }
            public int count { get; set; }
            public static bool operator >(CharacterCount node1, CharacterCount node2)
            {
                return node1.count > node2.count;
            }

            public static bool operator <(CharacterCount node1, CharacterCount node2)
            {
                return node1.count < node2.count;
            }

            public int CompareTo(CharacterCount obj)
            {
                return this.count - obj.count;
            }
        }
        public string ReorganizeString(string S)
        {
            if (string.IsNullOrEmpty(S)) return string.Empty;
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < S.Length; i++)
            {
                if (!dict.ContainsKey(S[i]))
                {
                    dict.Add(S[i], 0);
                }
                dict[S[i]]++;
            }
            var queue = new Queue<Tuple<char, int>>();
            var fmap = dict.OrderByDescending((x) => x.Value).ToList();
            var heap = new MaxHeap<CharacterCount>();
            foreach (var item in fmap)
            {
                heap.Add(new CharacterCount() { Cha = item.Key, count = item.Value });
            }
            char prev_added = ':';
            var sb = new StringBuilder();
            while (heap.Count > 0)
            {
                var item = heap.ExtractMax();
                if (item.Cha == prev_added)
                {
                    var temp = item;
                    if (heap.Count > 0)
                    {
                        var item2 = heap.ExtractMax();
                        sb.Append(item2.Cha);
                        prev_added = item2.Cha;
                        if (item2.count - 1 > 0)
                            heap.Add(new CharacterCount() { Cha = item2.Cha, count = item2.count - 1 });

                        heap.Add(new CharacterCount() { Cha = item.Cha, count = item.count });
                    }
                    else return string.Empty;
                }
                else
                {
                    sb.Append(item.Cha);
                    prev_added = item.Cha;
                    if (item.count - 1 > 0)
                        heap.Add(new CharacterCount() { Cha = item.Cha, count = item.count - 1 });
                }
            }
            return sb.ToString();
        }
        public class MaxHeap<T> where T : IComparable<T>
        {
            public IList<T> m_array;

            public MaxHeap()
            {
                m_array = new List<T>();
            }

            public MaxHeap(IList<T> array)
            {
                m_array = new List<T>(array);
            }

            public IList<T> GetList()
            {
                return m_array.ToList<T>();
            }
            public T GetRoot()
            {
                return m_array[0];
            }

            public T ExtractMax()
            {
                var result = m_array[0];
                m_array[0] = m_array[Count - 1];
                m_array.RemoveAt(m_array.Count - 1);
                ShiftDown(0);

                return result;
            }

            public void ShiftDown(int index)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int Index = index;

                if (left < Count && m_array[index].CompareTo(m_array[left]) < 0)
                {
                    index = left;
                }

                if (right < Count && m_array[index].CompareTo(m_array[right]) < 0)
                {
                    index = right;
                }

                if (index != Index)
                {
                    var temp = m_array[Index];
                    m_array[Index] = m_array[index];
                    m_array[index] = temp;

                    ShiftDown(index);
                }
            }
            public int Count
            {
                get
                {
                    return m_array.Count();
                }
            }

            private void Balance(int index)
            {
                if (index < 0)
                {
                    return;
                }

                int parent = (index - 1) / 2;

                if (m_array[parent].CompareTo(m_array[index]) < 0)
                {
                    var temp = m_array[parent];
                    m_array[parent] = m_array[index];
                    m_array[index] = temp;
                    Balance(parent);
                }
            }
            public void Add(T number)
            {
                m_array.Add(number);
                Balance(m_array.Count - 1);
                //BuildHeap();
            }

            private void BuildHeap()
            {
                for (int i = Count / 2; i >= 0; i--)
                {
                    Heapify(m_array, i);
                }
            }
            private void Heapify(IList<T> array, int index)
            {
                int N = array.Count;

                int Index = index;
                int left = 2 * index + 1;
                int right = 2 * index + 2;

                if (left < N && array[left].CompareTo(array[index]) > 0)
                {
                    index = left;
                }

                if (right < N && array[right].CompareTo(array[index]) > 0)
                {
                    index = right;
                }

                if (index != Index)
                {
                    var temp = array[Index];
                    array[Index] = array[index];
                    array[index] = temp;

                    Heapify(array, index);
                }

            }
        }

        public bool CanTransform(string start, string end)
        {
            int N = start.Length;
            if (N <= 0)
                return true;

            int i = -1, j = -1;
            while (i < N && j < N)
            {
                char a = 'X', b = 'X';
                for (i++; i < N; i++)
                {
                    a = start[i];
                    if (a != 'X') break;
                }
                for (j++; j < N; j++)
                {
                    b = end[j];
                    if (b != 'X') break;
                }
                if (a != b) return false;
                if (a == 'L' && j > i) return false;
                if (a == 'R' && j < i) return false;
            }
            return true;
        }

        public bool ValidTicTacToe(string[] board)
        {
            int turns = 0;
            bool xwin = false;
            bool owin = false;
            int[] rows = new int[3];
            int[] cols = new int[3];
            int diag = 0;
            int antidiag = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i][j] == 'X')
                    {
                        turns++; rows[i]++; cols[j]++;
                        if (i == j) diag++;
                        if (i + j == 2) antidiag++;
                    }
                    else if (board[i][j] == 'O')
                    {
                        turns--; rows[i]--; cols[j]--;
                        if (i == j) diag--;
                        if (i + j == 2) antidiag--;
                    }
                }
            }

            xwin = rows[0] == 3 || rows[1] == 3 || rows[2] == 3 ||
                   cols[0] == 3 || cols[1] == 3 || cols[2] == 3 ||
                   diag == 3 || antidiag == 3;
            owin = rows[0] == -3 || rows[1] == -3 || rows[2] == -3 ||
                   cols[0] == -3 || cols[1] == -3 || cols[2] == -3 ||
                   diag == -3 || antidiag == -3;

            if (xwin && turns == 0 || owin && turns == 1)
            {
                return false;
            }
            return (turns == 0 || turns == 1) && (!xwin || !owin);
        }

        public bool IsIdealPermutation(int[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                int n = A[i] - i;
                if (n >= 2)
                {
                    return false;
                }
                else if (n == 1 && A[i] < A[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        public int KthGrammar(int N, int K)
        {
            return Get(N, K);
        }

        public int Get(int r, int i)
        {
            int count = (int)Math.Pow(2, r - 1);
            int half = count / 2;
            int halvesHalf = half / 2;

            if (i <= 4)
            {
                return new int[] { 0, 1, 1, 0 }[i - 1];
            }
            else
            {
                if (i > half)
                {
                    if (i - half > halvesHalf)
                    {
                        return Get(r - 1, i - half - halvesHalf);
                    }
                    else
                    {
                        return Get(r - 1, halvesHalf + i - half);
                    }
                }
                else
                {
                    return Get(r - 1, i);
                }
            }
        }

        public bool IsBipartite(int[][] graph)
        {
            int nodesCount = graph.Length;
            int[] colorOfNode = new int[nodesCount];
            for (int i = 0; i < nodesCount; i++)
                colorOfNode[i] = -1;               //-1 represent no color;

            for (int i = 0; i < nodesCount; i++)
                if (colorOfNode[i] == -1 && !CheckForValidColorDFS(graph, colorOfNode, i, 0))
                    return false;

            return true;
        }

        private static bool CheckForValidColorDFS(int[][] graph, int[] colorOfNode, int node, int color)
        {
            if (colorOfNode[node] != -1)
                return colorOfNode[node] == color;

            colorOfNode[node] = color;
            for (int i = 0; i < graph[node].Length; i++)
                if (!CheckForValidColorDFS(graph, colorOfNode, graph[node][i], color == 1 ? 0 : 1))
                    return false;

            return true;
        }
        int minDistance = int.MaxValue;
        Dictionary<int, List<Edge>> adjacencyList;

        public int FindCheapestPrice1(int n, int[,] flights, int src, int dst, int K)
        {
            GenerateAdjacencyList(flights);
            DFS(src, dst, K, 0, 0);

            return minDistance == int.MaxValue ? -1 : minDistance;
        }

        public void GenerateAdjacencyList(int[,] flights)
        {
            adjacencyList = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < flights.GetLength(0); i++)
            {
                int source = flights[i, 0];
                int destination = flights[i, 1];
                int distance = flights[i, 2];
                if (adjacencyList.ContainsKey(source))
                {
                    adjacencyList[source].Add(new Edge() { destination = destination, distance = distance });
                }
                else
                {
                    adjacencyList.Add(source, new List<Edge>(){
                    new Edge() { destination = destination, distance = distance }
                });
                }
            }
        }

        public void DFS(int src, int dst, int K, int currentDepth, int total)
        {
            if (!adjacencyList.ContainsKey(src))
            {
                return;
            }

            List<Edge> edges = adjacencyList[src];

            foreach (var edge in edges)
            {
                int totalAtThisDepth = total + edge.distance;
                if (edge.destination == dst)
                {
                    if (minDistance > totalAtThisDepth)
                    {
                        minDistance = totalAtThisDepth;
                    }
                }
                else if (currentDepth + 1 <= K && totalAtThisDepth < minDistance)
                {
                    DFS(edge.destination, dst, K, currentDepth + 1, totalAtThisDepth);
                }

            }

        }

        private int[] _visitedCities;
        private int _bestPrice = int.MaxValue;

        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            _visitedCities = new int[n];
            var fc = new Dictionary<int, List<int[]>>();

            foreach (var f in flights)
                if (fc.ContainsKey(f[0]))
                    fc[f[0]].Add(f);
                else
                    fc.Add(f[0], new List<int[]>() { f });

            Fly(fc, src, dst, 0, K);
            return _bestPrice == int.MaxValue ? -1 : _bestPrice; ;
        }

        private void Fly(Dictionary<int, List<int[]>> fc, int src, int dst, int price, int K)
        {
            if (src == dst)
                _bestPrice = Math.Min(price, _bestPrice);
            else if (K >= 0 && fc.ContainsKey(src))
                foreach (var flight in fc[src].Where(f => _visitedCities[f[1]] == 0 && price + f[2] <= _bestPrice))
                {
                    _visitedCities[src] = 1;
                    Fly(fc, flight[1], dst, price + flight[2], K - 1);
                    _visitedCities[src] = 0;
                }
        }

        public int NumTilings(int N)
        {
            int a = 0, b = 1, c = 1, c2, mod = 1000000007;
            while (--N > 0)
            {
                c2 = (c * 2 % mod + a) % mod;
                a = b;
                b = c;
                c = c2;
            }
            return c;
        }

        public int NumMatchingSubseq(string S, string[] words)
        {
            int n = S.Length;
            int[,] next = new int[n + 1,26];
            char[] sc = S.ToCharArray();
            for (int i = 0; i < next.GetLength(1); i++) next[n, i] = -1;
            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = 0; j < 26; j++)
                {
                    next[i,j] = next[i + 1,j];
                }
                next[i,sc[i] - 'a'] = i + 1;
            }
            int res = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (isSubseq(next, words[i])) res++;
            }
            return res;

        }

        public bool isSubseq(int[,] next, String s)
        {
            char[] sc = s.ToCharArray();
            int j = 0;
            for (int i = 0; i < sc.Length; i++)
            {
                char c = sc[i];
                if (next[j,c - 'a'] > -1) j = next[j,c - 'a'];
                else return false;
            }
            return true;
        }

        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            double[] res = new double[101];
            res[0] = poured;
            for (int row = 1; row <= query_row; row++)
                for (int i = row; i >= 0; i--)
                    res[i + 1] += res[i] = Math.Max(0.0, (res[i] - 1) / 2);
            return Math.Min(res[query_glass], 1.0);
        }

        public int MinSwap(int[] A, int[] B)
        {
            int N = A.Length;
            int[] swap = new int[1000];
            int[] not_swap = new int[1000];
            swap[0] = 1;
            for (int i = 1; i < N; ++i)
            {
                not_swap[i] = swap[i] = N;
                if (A[i - 1] < A[i] && B[i - 1] < B[i])
                {
                    not_swap[i] = not_swap[i - 1];
                    swap[i] = swap[i - 1] + 1;
                }
                if (A[i - 1] < B[i] && B[i - 1] < A[i])
                {
                    not_swap[i] = Math.Min(not_swap[i], swap[i - 1]);
                    swap[i] = Math.Min(swap[i], not_swap[i - 1] + 1);
                }
            }
            return Math.Min(swap[N - 1], not_swap[N - 1]);
        }



    }

    public struct Edge
    {
        public int destination
        {
            get;
            set;
        }
        public int distance
        {
            get;
            set;
        }
    }



    public class Node
    {
        public int id;
        public Node parent; // Will be set during traversal
        public List<Node> neighbours;

        public Node(int id)
        {
            this.id = id;
            this.neighbours = new List<Node>();
        }

        public void addNeighbour(Node n)
        {
            this.neighbours.Add(n);
            n.neighbours.Add(this);
        }
    }


    public static class ArrayExtensions
    {

        public static T[][] To2D<T>(this T[,] arr)
        {
            var ret = new T[arr.GetLength(0)][];
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                ret[i] = new T[arr.GetLength(1)];
                for (var j = 0; j < arr.GetLength(1); j++)
                {
                    ret[i][j] = arr[i, j];
                }
            }

            return ret;
        }

        public static T[,] To2D<T>(this T[][] arr)
        {
            var ret = new T[arr.Length, arr[0].Length];
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr[0].Length; j++)
                {
                    ret[i, j] = arr[i][j];
                }
            }

            return ret;
        }

    }

    public class Point
    {
        public int x;
        public int y;
        public Point() { x = 0; y = 0; }
        public Point(int a, int b) { x = a; y = b; }
    }

    public class TrieNode
    {
        public TrieNode[] sons;
        public bool isEnd;
        public TrieNode()
        {
            sons = new TrieNode[26];
        }
    }


    public class Project
    {
        public int profit;
        public int capital;
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }


    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Deque
    {
        List<Tuple<int, int>> list;

        public Deque()
        {
            list = new List<Tuple<int, int>>();
        }

        public bool Exists()
        {
            return list.Count > 0;
        }

        public void AddFirst(Tuple<int, int> i)
        {
            list.Insert(0, i);
        }

        public void AddLast(Tuple<int, int> i)
        {
            list.Add(i);
        }

        public Tuple<int, int> GetFirst()
        {
            Tuple<int, int> i = list[0];
            list.RemoveAt(0);
            return i;
        }

        public Tuple<int, int> GetLast()
        {
            Tuple<int, int> i = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return i;
        }

        public Tuple<int, int> PeekFirst()
        {
            Tuple<int, int> i = list[0];
            return i;
        }

        public Tuple<int, int> PeekLast()
        {
            Tuple<int, int> i = list[list.Count - 1];
            return i;
        }

        public void Debug()
        {
            Console.WriteLine(String.Join(",", list.Select(t => string.Format(" {0}({1}) ", t.Item1, t.Item2))));
        }
    }

    public class MedianFinder
    {
        IntMaxHeap lo;
        IntMinHeap hi;
        double median;
        const int MAXSIZE = 100000000;
        public MedianFinder()
        {
            lo = new IntMaxHeap(MAXSIZE);
            hi = new IntMinHeap(MAXSIZE);
            median = 0;
        }

        public void AddNum(int num)
        {
            //Add the element
            if ((lo.size == 0 && hi.size == 0) || num <= median)
            {
                lo.Add(num);
            }
            else
            {
                hi.Add(num);
            }

            //Balance the heaps
            if (lo.size - hi.size > 1)
            {
                hi.Add(lo.ExtractTop());
            }
            else if (hi.size - lo.size > 1)
            {
                lo.Add(hi.ExtractTop());
            }

            //Update the median
            if (lo.size > hi.size)
            {
                median = lo.PeekTop();
            }
            else if (hi.size > lo.size)
            {
                median = hi.PeekTop();
            }
            else
            {
                median = ((double)lo.PeekTop() + hi.PeekTop()) / 2;
            }

        }

        public double FindMedian() => median;
    }

    public class Heap<T>
    {
        protected T[] arr;
        public int size;
        public Heap(int size)
        {
            arr = new T[size];
            size = 0;
        }
        //Adds an element to the heap while maintaining the heap property
        public void Add(T num)
        {
            size++;
            arr[size - 1] = num;
            int parent = Parent(size - 1);
            while (parent > 0)
            {
                Heapify(parent);
                parent = Parent(parent);
            }
            Heapify(0);
        }
        //Removes and returns the top element from heap
        public T ExtractTop()
        {
            T root = arr[0];
            arr[0] = arr[size - 1];
            size--;
            if (size > 0) { Heapify(0); }
            return root;
        }
        //Returns the top element from heap
        public T PeekTop()
        {
            return arr[0];
        }
        //Heapifies the tree starting the from node with index i. Assumes that only the given node needs to be placed
        //at the appropriate position and rest of the tree is already heapified
        private void Heapify(int i)
        {
            int l = Left(i);
            int r = Right(i);
            int curTopIndex = i;
            if (l < size && Compare(arr[l], arr[i]))
            {
                curTopIndex = l;
            }
            if (r < size && Compare(arr[r], arr[curTopIndex]))
            {
                curTopIndex = r;
            }
            //if current node was at incorrect location, swap with appropriate child and recurse
            if (curTopIndex != i)
            {
                Swap(arr, i, curTopIndex);
                Heapify(curTopIndex);
            }
        }
        //Let the child classes implement it
        protected virtual bool Compare(T a, T b)
        {
            throw new Exception("Compare not implemented");
            //return false;
        }

        private int Parent(int i) => (i - 1) / 2;
        private int Left(int i) => 2 * i + 1;
        private int Right(int i) => 2 * i + 2;
        private void Swap(T[] a, int i, int j)
        {
            T temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }
    }
    public class IntMinHeap : Heap<int>
    {
        public IntMinHeap(int size) : base(size) { }
        protected override bool Compare(int a, int b) => a < b;
    }
    public class IntMaxHeap : Heap<int>
    {
        public IntMaxHeap(int size) : base(size) { }
        protected override bool Compare(int a, int b) => a > b;
    }
}
