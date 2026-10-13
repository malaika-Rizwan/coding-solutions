
public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        bool[] visited = new bool[arr.Length];

        return DFS(arr, start, visited);
    }

    private bool DFS(int[] arr, int index, bool[] visited)
    {
        // Check array boundaries
        if (index < 0 || index >= arr.Length)
            return false;

        // Avoid visiting the same index repeatedly
        if (visited[index])
            return false;

        // Found zero
        if (arr[index] == 0)
            return true;

        visited[index] = true;

        // Try jumping right or left
        return DFS(arr, index + arr[index], visited) ||
               DFS(arr, index - arr[index], visited);
    }
}
