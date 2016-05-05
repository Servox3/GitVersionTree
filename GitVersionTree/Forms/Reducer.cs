using System;
using System.Collections.Generic;

namespace GitVersionTree
{
    internal class Reducer
    {
        public Reducer()
        {
        }

        public List<List<string>> ReduceNodes(List<List<string>> nodes, Dictionary<string, string> decorateDictionary)
        {
            var parents = new Dictionary<string, List<string>>();
            var children = new Dictionary<string, List<string>>();
            var result = new List<List<string>>();
            foreach (var nodeList in nodes)
            {
                var resultNodeList = new List<string>();
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
                    //if (decorateDictionary.ContainsKey(node))
                    //{
                    //    resultNodeList.Add(node);
                    //}
                    //else
                    //{
                    //    foreach (var innerNodeList in nodes)
                    //    {
                    //        if (!innerNodeList.Equals(nodeList))
                    //        {
                    //            //Add the node if it's the last node in any other list
                    //            //if (innerNodeList[innerNodeList.Count - 1].Equals(node))
                    //            //{
                    //            //    resultNodeList.Add(node);
                    //            //}
                    //            //if (innerNodeList[0].Equals(node))
                    //            //{
                    //            //    resultNodeList.Add(node);
                    //            //}
                    //            //else if(innerNodeList[0].Equals(node))
                    //            //{
                    //            //    resultNodeList.Add(node);
                    //            //}
                    //            //if (innerNodeList.Contains(node))
                    //            //{
                    //            //    if (parents[node].Count > 1)
                    //            //    {
                    //            //        resultNodeList.Add(node);
                    //            //    }
                    //            //}

                    //            ////Add the node if it has multiple parents
                    //            //if (parents[node].Count > 1)
                    //            //{
                    //            //    resultNodeList.Add(node);
                    //            //}

                    //            //Add the node and its parents if it has multiple parents
                    //            if (parents[node].Count > 1)
                    //            {
                    //                foreach (var parent in parents[node])
                    //                {
                    //                    resultNodeList.Add(parent);
                    //                }
                    //                resultNodeList.Add(node);
                    //            }
                    //            //Add the node and its children if it has multiple children
                    //            if (children[node].Count > 1)
                    //            {
                    //                resultNodeList.Add(node);
                    //                foreach (var child in children[node])
                    //                {
                    //                    resultNodeList.Add(child);
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                }

                ////Add all nodes that has multiple parents and/or multiple children
                //foreach (var node in parents.Keys)
                //{
                //    if (parents[node].Count > 1)
                //    {
                //        foreach (var parent in parents[node])
                //        {
                //            result.Add(new List<string> { parent, node });
                //        }
                //    }
                //}
                //foreach (var node in children.Keys)
                //{
                //    if (children[node].Count > 1)
                //    {
                //        foreach (var child in children[node])
                //        {
                //            result.Add(new List<string> { node, child });
                //        }
                //    }
                //}

                ////Connect last node in list if it has an ancestor with multiple parents
                //foreach (var node in nodeList)
                //{
                //    if (parents[node].Count > 1)
                //    {
                //        result.Add(new List<string> { node, nodeList[nodeList.Count - 1] });
                //    }
                //}

                //if (resultNodeList.Count == 0)
                ////No nodes was decorated
                //{
                //    //Add the first and last nodes anyway
                //    resultNodeList.Add(nodeList[0]);
                //    resultNodeList.Add(nodeList[nodeList.Count - 1]);
                //}
                //result.Add(resultNodeList);
            }

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
                        if (node != nodeList[0])
                        {
                            var parentInThisList = nodeList[nodeList.IndexOf(node) - 1];
                            if (!reducedList.Contains(parentInThisList))
                            {
                                reducedList.Add(parentInThisList);
                            }
                        }
                        reducedList.Add(node);
                    }
                    else if (children[node].Count > 1)
                    {
                        reducedList.Add(node);
                        if (node != nodeList[nodeList.Count - 1])
                        {
                            var childInThisList = nodeList[nodeList.IndexOf(node) + 1];
                            if (!reducedList.Contains(childInThisList))
                            {
                                reducedList.Add(childInThisList);
                            }
                        }
                    }
                    else if (decorateDictionary.ContainsKey(node))
                    {
                        reducedList.Add(node);
                    }
                    else if (children[node].Count > 1)
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