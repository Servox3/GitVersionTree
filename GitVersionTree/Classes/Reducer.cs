﻿using System;
using System.Collections.Generic;

namespace GitVersionTree
{
    public class Reducer
    {
        Dictionary<string, List<string>> parents = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> children = new Dictionary<string, List<string>>();

        public List<List<string>> ReduceNodes(List<List<string>> nodes, Dictionary<string, string> decorateDictionary)
        {
            foreach (var nodeList in nodes)
            {
                foreach (var node in nodeList)
                {
                    if (!parents.ContainsKey(node))
                    {
                        //Prepare lookup of parents for node
                        parents[node] = new List<string>();
                    }
                    if (node != nodeList[0])
                    {
                        //Add direct parent to the node
                        var parentNode = nodeList[nodeList.IndexOf(node) - 1];
                        if (!parents[node].Contains(parentNode))
                        {
                            parents[node].Add(parentNode);
                        }
                    }
                    if (!children.ContainsKey(node))
                    {
                        //Prepare lookup of children for node
                        children[node] = new List<string>();
                    }
                    if (node != nodeList[nodeList.Count - 1])
                    {
                        //Add direct child to the node
                        var childNode = nodeList[nodeList.IndexOf(node) + 1];
                        if (!children[node].Contains(childNode))
                        {
                            children[node].Add(childNode);
                        }
                    }
                }
            }
            return FilterNodes(nodes, decorateDictionary, true);
        }

        /// <summary>
        /// Removes nodes that have only one parent and one child
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="decorateDictionary"></param>
        /// <param name="strong">Set to true to remove more nodes</param>
        /// <returns></returns>
        private List<List<string>> FilterNodes(List<List<string>> nodes, Dictionary<string, string> decorateDictionary, bool strong)
        {
            List<List<string>> result = new List<List<string>>();
            // Check each node, if it should be in the graph
            foreach (var nodeList in nodes)
            {
                var reducedList = new List<string>();
                foreach (var node in nodeList)
                {
                    if (reducedList.Contains(node))
                    {
                        continue;
                    }
                    if (parents[node].Count > 1)
                    {
                        if (!strong)
                        {
                            if (node != nodeList[0])
                            {
                                var parentInThisList = nodeList[nodeList.IndexOf(node) - 1];
                                if (!reducedList.Contains(parentInThisList))
                                {
                                    reducedList.Add(parentInThisList);
                                }
                            }
                        }
                        reducedList.Add(node);
                    }
                    else if (children[node].Count > 1)
                    {
                        reducedList.Add(node);
                        if (!strong)
                        {
                            if (node != nodeList[nodeList.Count - 1])
                            {
                                var childInThisList = nodeList[nodeList.IndexOf(node) + 1];
                                if (!reducedList.Contains(childInThisList))
                                {
                                    reducedList.Add(childInThisList);
                                }
                            }
                        }
                    }
                    else if (decorateDictionary.ContainsKey(node))
                    {
                        reducedList.Add(node);
                    }
                    else if (parents[node].Count == 0)
                    {
                        reducedList.Add(node);
                    }
                }
                result.Add(reducedList);
            }
            return result;
        }
    }
}